using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Collections;
using System.Security.AccessControl;
using System.IO;

namespace PlexPhotoCacheExporter
{
    public class SQLiteReader
    {
        public SQLiteConnection conn;
        string sqlFile;
        string outPath;
        string cachePath;

        //Containers
        List<DirectoryMeta> sections;
        List<DirectoryMeta> paths;
        List<MediaItemMeta> media;

        public void Initialize(string path, string output, string cache)
        {
            sqlFile = path;
            outPath = output;
            cachePath = cache;
            conn = new SQLiteConnection("Data Source=" + sqlFile);

            sections = new List<DirectoryMeta>();
            paths = new List<DirectoryMeta>();
            media = new List<MediaItemMeta>();
        }

        public string[] FindSections()
        {
            SQLiteDataAdapter ad;
            DataTable temp = new DataTable();
            List<string> tempList = new List<string>();
            try
            {
                SQLiteCommand cmd;
                conn.Open();
                cmd = conn.CreateCommand();

                //Top Level of Sections (a.k.a. Plex "Parent_Directory")
                cmd.CommandText = "SELECT x.* FROM library_sections x";
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(temp);
            }
            catch (SQLiteException ex)
            {
                //Add your exception code here.
            }
            conn.Close();
            
            foreach (DataRow dr in temp.Rows)
            {
                DirectoryMeta dm = new DirectoryMeta();
                dm.ID = dr["id"].ToString();
                dm.Path = dr["name"].ToString();
                sections.Add(dm);
                tempList.Add(dm.Path);
            }

            return tempList.ToArray();
        }

        public List<DirectoryMeta> ReadDirectories(int sectionID)
        {
            SQLiteDataAdapter ad;
            DataTable temp = new DataTable();
            try
            {
                SQLiteCommand cmd;
                conn.Open();
                cmd = conn.CreateCommand();

                //Top Level of Sections (a.k.a. Plex "Parent_Directory")
                cmd.CommandText = "SELECT x.* FROM directories x WHERE library_section_id = " + (sectionID +1 ); //Have to offset by 1 because Plex uses a non zero index
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(temp);
            }
            catch (SQLiteException ex)
            {
                //Add your exception code here.
            }
            conn.Close();

            foreach (DataRow dr in temp.Rows)
            {
                DirectoryMeta dm = new DirectoryMeta();
                dm.ID = dr["id"].ToString();
                dm.ParentID = dr["parent_directory_id"].ToString();
                dm.SectionID = dr["library_section_id"].ToString();
                dm.Path = dr["path"].ToString();
                paths.Add(dm);
            }

            outPath = outPath + "\\" + sections[sectionID].Path;

            return paths;
        }

        //Data within media_items - All we really get from here is what IDs correspond to what extensions within the section we want
        public List<MediaItemMeta> ReadMediaItems(int section, string searchExt)
        {
            SQLiteDataAdapter ad;
            DataTable items = new DataTable();
            DataTable parts = new DataTable();
            DataTable metas = new DataTable();
            try
            {
                SQLiteCommand cmd;
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT x.* FROM media_items x WHERE container = '" + (searchExt) + "' AND library_section_id = " + section;
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(items);

                foreach (DataRow dr in items.Rows)
                {
                    MediaItemMeta photo = new MediaItemMeta();

                    photo.ID = dr["id"].ToString();
                    photo.Container = dr["container"].ToString();
                    photo.SectionID = dr["library_section_id"].ToString();
                    photo.MetadataID = dr["metadata_item_id"].ToString();

                    media.Add(photo);
                }

                cmd.CommandText = "SELECT x.* FROM metadata_items x WHERE library_section_id = " + section;
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(metas);

                for(int q = 0; q < media.Count; q++)
                {
                    MediaItemMeta m = media[q];

                    for (int i = 0; i < metas.Rows.Count; i++)
                    {
                        DataRow dr = metas.Rows[i];
                        if (m.MetadataID == dr["id"].ToString())
                        {
                            string localPath = dr["user_thumb_url"].ToString();
                            string t = localPath.Replace("media://", "");
                            string f = t.Replace('/', '\\');
                            m.ThumbURL = localPath;
                            m.SourceFile = cachePath + "\\" + t;
                            m.FileName = dr["title"].ToString() + "." + searchExt;
                        }

                    }
                }

                cmd.CommandText = "SELECT x.* FROM media_parts x";
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(parts);

                for (int q = 0; q < media.Count; q++)
                {
                    MediaItemMeta m = media[q];

                    for (int i = 0; i < parts.Rows.Count; i++)
                    {
                        DataRow dr = parts.Rows[i];
                        if (m.ID == dr["media_item_id"].ToString())
                        {
                            string p = dr["file"].ToString();
                            List<string> lines = p.Split('\\').ToList();
                            lines.Remove(lines.First());
                            lines.Remove(lines.Last());
                            lines.Remove(lines.First()); //Second Line which is root path

                            string t = string.Join("\\", lines);
                            m.DestinationFile = outPath + "\\" + t + "\\" + m.FileName;
                        }
                    }
                }

            }
            catch (SQLiteException ex)
            {
                //Add your exception code here.
            }
            conn.Close();
            return media;
        }

        public void WriteDirectories(int rSectionIDX)
        {
            Directory.CreateDirectory(outPath);

            foreach (DirectoryMeta dm in paths)
            {
                Directory.CreateDirectory(outPath + "\\" + dm.Path);
            }

            Thread.Sleep(1000);
        }

        public void WriteMediaItems()
        {
            foreach (MediaItemMeta m in media)
            {
                if (File.Exists(m.SourceFile) && !File.Exists(m.DestinationFile))
                {
                    File.Copy(m.SourceFile, m.DestinationFile);
                    Thread.Sleep(100);
                }
            }
        }
    }
}

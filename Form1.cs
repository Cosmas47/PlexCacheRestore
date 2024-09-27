using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace PlexPhotoCacheExporter
{
    public partial class Form1 : Form
    {
        string sql_path;
        string out_path;
        string cache_path;

        public Form1()
        {
            InitializeComponent();
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            btn_Export.Enabled = false;
            sectionDropDown.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "com.plexapp.plugins.library.db";
            openFileDialog.InitialDirectory = "%APPDATA%\\Local\\Plex Media Server\\Plug-in Support\\Databases";
            openFileDialog.Filter = "SQqlite DB Files(*.db) | *.db";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                sql_path = openFileDialog.FileName;
                textBox1.Text = openFileDialog.FileName;
                checkBox1.Checked = true;
                sectionDropDown.Enabled = true;
                sectionDropDown.Items.Clear();

                SQLiteReader reader = new SQLiteReader();
                reader.Initialize(sql_path, out_path, cache_path);
                sectionDropDown.Items.AddRange(reader.FindSections());
            }
            else
            {
                sql_path = "";
                textBox1.Text = "";
                checkBox1.Checked = false;
                sectionDropDown.Enabled = false;
            }
            Ready();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                out_path = fbd.SelectedPath;
                textBox2.Text = fbd.SelectedPath;
                checkBox2.Checked = true;
            }
            else
            {
                out_path = "";
                textBox2.Text = "";
                checkBox2.Checked = false;
            }
            Ready();
        }


        void Ready()
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox4.Checked)
            {
                checkBox3.Checked = true;
                btn_Export.Enabled = true;
            }
            else
            {
                checkBox3.Checked = false;
                btn_Export.Enabled = false;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SQLiteReader reader = new SQLiteReader();

            reader.Initialize(sql_path, out_path, cache_path);

            reader.FindSections();

            int section = sectionDropDown.SelectedIndex;

            reader.ReadDirectories(section);

            string[] extensions = textBox3.Text.Split(",");

            foreach (string extension in extensions)
                reader.ReadMediaItems(section + 1, extension);

            reader.WriteDirectories(section);

            reader.WriteMediaItems();
        }

        private void btn_Cache_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                cache_path = fbd.SelectedPath;
                textBox4.Text = fbd.SelectedPath;
                checkBox4.Checked = true;
            }
            else
            {
                cache_path = "";
                textBox4.Text = "";
                checkBox4.Checked = false;
            }
            Ready();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

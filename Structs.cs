using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexPhotoCacheExporter
{
    public class DirectoryMeta
    {
        public string ID;
        public string SectionID;
        public string ParentID;
        public string Path;
    }

    public class MediaItemMeta
    {
        public string ID;
        public string SectionID;
        public string Container;
        public string FileName;
        public string SourceFile;
        public string DestinationFile;
        public string MetadataID;
        public string ThumbURL;
    }

}

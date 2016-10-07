using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBackups.UI.Models
{
    public class SourceFolder
    {
        public DirectoryInfo DirectoryInfo { get; set;  }
        public FileInfo[] FileInfos { get; set; }
        public long DirectoryTotalSizeInBytes { get; set; }

        public SourceFolder(string folderFullPath)
        {
            this.DirectoryInfo = new DirectoryInfo(folderFullPath);
            this.FileInfos = this.DirectoryInfo.GetFiles();
            this.DirectoryTotalSizeInBytes = this.FileInfos
                .Select(x => x.Length)
                .Sum();
        }
    }
}

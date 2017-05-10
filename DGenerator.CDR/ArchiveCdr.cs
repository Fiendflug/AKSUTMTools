using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;

namespace DGenerator.CDR
{
    public class ArchiveCdr
    {
        string[] FilePaths { get; set; }
        string ArchivePath { get; set; }
        string ArchiveName { get; set; }

        public delegate void ZipDelegate();
        public event ZipDelegate ZipOneCdrEvent;

        public ArchiveCdr(string[] filePaths, string archivePath, string archiveName)
        {
            FilePaths = filePaths;
            ArchivePath = archivePath;
            ArchiveName = archiveName;

            ZipOneCdrEvent = delegate { };
        }

        public void StartCompress()
        {
            using (var zip = new ZipFile(Path.Combine(ArchivePath, ArchiveName)))
            {
                zip.CompressionLevel = CompressionLevel.Default;
                foreach (var cdr in FilePaths)
                {
                    var tempFileName = Path.GetFileName(cdr);
                    zip.AddFile(cdr, ArchiveName);
                    ZipOneCdrEvent();
                }
                zip.Save();
            }
        }
    }
}

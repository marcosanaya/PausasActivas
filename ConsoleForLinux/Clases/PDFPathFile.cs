using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    public class PDFPathFile
    {
        public FileInfo File { get; set; }

        public bool HasImageFiles { get; set; }

        public string HashResource { get; set; } = string.Empty;

        public List<FileInfo> ImageFiles { get; set; }

        public PDFPathFile()
        {
            ImageFiles = [];
        }
    }
}

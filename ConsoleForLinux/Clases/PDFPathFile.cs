using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    public class PDFPathFile
    {
        public string FileName { get; set; } = string.Empty;
        
        public string Path { get; set; } = string.Empty;

        public string Extension { get; set; } = string.Empty;

        public bool HasImageFiles { get; set; }

        public string HashResource { get; set; } = string.Empty;

        public List<FileImageDetail> ImageFiles { get; set; }

        public PDFPathFile()
        { 
            ImageFiles = [];
        }

        public class FileImageDetail
        {
            public string FileName { get; set; } = string.Empty;

            public string Extension {  get; set; } = string.Empty ;

            public DateTime DateModified { get; set; }

            public string HashResource { get; set; } = string.Empty;

            public FileImageDetail()
            {
                
            }
        }
    }
}

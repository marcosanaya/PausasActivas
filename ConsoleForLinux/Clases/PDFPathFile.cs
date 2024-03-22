using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    public class PDFPathFile
    {
        public string Name { get; set; } = string.Empty;

        public required FileInfo File { get; set; }

        public bool HasImageFiles { get; set; }

        public string HashResources { get; set; } = string.Empty;

        public List<ImageResource> ImageFiles { get; set; } = [];

        public PDFPathFile()
        {
            ImageFiles = [];
        }
    }

    public class ImageResource
    {
        public FileInfo? PhysicalImage { get; set; }

        public int Width{ get; set; }
        
        public int Height { get; set; }

        public string MimeFormat { get; set; } = string.Empty ;

        public ImageResource(FileInfo img)
        {
            this.PhysicalImage = img;
        }
    }
}

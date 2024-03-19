using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    public class DSpaceItem
    {
        public string ID { get; set; }
        public string UUID { get; set; }
        public string PDFFileName { get; set; }
        public bool HasImageFiles { get; set; }
        public bool Synchronized { get; set; }

        public DSpaceItem()
        {
            ID = string.Empty;
            UUID = string.Empty;
            PDFFileName = string.Empty;
        }
    }
}

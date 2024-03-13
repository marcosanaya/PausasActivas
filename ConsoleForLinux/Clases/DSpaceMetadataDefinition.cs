using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    public class DSpaceMetadataDefinition
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Language { get; set; }
        public int Place { get; set; }

        public DSpaceMetadataDefinition()
        {
            Name = string.Empty;
            Value = string.Empty;
            Language = string.Empty;
        }
    }
}

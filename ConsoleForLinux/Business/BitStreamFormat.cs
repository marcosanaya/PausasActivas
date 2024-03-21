using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleForLinux.Business
{
    public class BitStreamFormat
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("description")]
        public string Description{ get; set; }
        [JsonPropertyName("mimetype")]
        public string MimeType{ get; set; }
        [JsonPropertyName("extensions")]
        public List<string> Extensions { get; set; }

        public BitStreamFormat()
        {
            Extensions = [];
            Description = string.Empty;
            MimeType = string.Empty;
        }
    }
}

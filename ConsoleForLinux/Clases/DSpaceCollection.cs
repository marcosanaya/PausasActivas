using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    public class DSpaceCollection
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("handle")]
        public string Handle { get; set; }

        [JsonPropertyName("type")]
        public string Type{ get; set; }

        public DSpaceCollection()
        {
            ID = string.Empty;
            Name = string.Empty;
            Handle = string.Empty;
            UUID = string.Empty;
            Type = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    public sealed class ProcessParams
    {
        public ProcessParams()
        {
            ResourcePath=string.Empty;
            Host=string.Empty;
            User=string.Empty;
            Password = string.Empty;
            Collections = [];
            ProxyUser = string.Empty;
            ProxyPassword = string.Empty;
        }

        [JsonPropertyName("ResourcePath")]
        public string ResourcePath { get; set; }

        [JsonPropertyName("Host")]
        public string Host { get; set; }

        [JsonPropertyName("User")]
        public string User { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }

        [JsonPropertyName("Collections")]
        public List<string> Collections { get; set;}

        [JsonPropertyName("UseProxy")]
        public bool? UseProxy { get; set; }

        [JsonPropertyName("ProxyUser")]
        public string ProxyUser { get; set; }

        [JsonPropertyName("ProxyPassword")]
        public string ProxyPassword { get; set; }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ProcessParams))]
    internal partial class ParamsContext : JsonSerializerContext { }

}
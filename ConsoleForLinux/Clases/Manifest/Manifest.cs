using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases.Manifest
{
    public class Manifest
    {
        private readonly ProcessParams? parametros;
        private ConstantsMetada? constants;

        [JsonPropertyName("@id")]
        public string? ID { get; set; }

        [JsonPropertyName("@context")]
        public string? Context { get; set; }

        [JsonPropertyName("@type")]
        public string? Type { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }
        //public List<Metadata> Metas { get; set; }
        //public List<Sequence> Sequences { get; set; }
        //public Thumbnail Thumb { get; set; }

        public Manifest(DSpaceCollection dspaceitem, ProcessParams config)
        {
            if(dspaceitem == null)
                return;
            parametros = config;
            constants = new(config);
            Context = ConstantsMetada.ManifestContext;
            Type = ConstantsMetada.ManifestType;
            ID = constants.GetContextID(dspaceitem.UUID);
            var info = dspaceitem.Metadata.FirstOrDefault(m => m.Name.Equals("dc.title"));
            Label = (info != null) ? info.Value : string.Empty;
        }
    }
}
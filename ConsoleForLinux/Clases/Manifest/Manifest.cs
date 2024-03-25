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
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("@context")]
        public string Context { get; set; } = string.Empty ;

        [JsonPropertyName("@type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        [JsonPropertyName("metadata")]
        public List<Metadata> Metas { get; set; } = [];

        [JsonPropertyName("sequences")]
        public List<Sequence> Sequences { get; set; } = [];

        [JsonPropertyName("thumbnail")]
        public Thumbnail? Thumb { get; set; }

        public Manifest(DSpaceCollection dspaceitem, List<ImageResource> imageFiles, ProcessParams config)
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
            Label = string.Concat(Label, " ", "Anaya.");
            if (imageFiles.Count > 0)
                Thumb = new(imageFiles[0], config);
            Sequences = constants.GetSequencesManifest(imageFiles);
            Metas = ConstantsMetada.GetMetadataManifest(dspaceitem);
        }
    }
}
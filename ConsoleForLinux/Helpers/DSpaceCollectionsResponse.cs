using ConsoleForLinux.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static ConsoleForLinux.Helpers.DSpaceCollectionsResponse;

namespace ConsoleForLinux.Helpers
{
    public sealed class DSpaceCollectionsResponse
    {
        [JsonRequired]
        [JsonPropertyName("_embedded")]
        public EmbeddedObject Embedded { get; set; }

        //[JsonPropertyName("_links")]
        //public object Links { get; set; }

        [JsonPropertyName("page")]
        public DSpacePagination Pagination { get; set; }

        public DSpaceCollectionsResponse()
        {
            Embedded = new();
            Pagination = new();
            //Links = new object();
        }

        public class EmbeddedObject
        {
            [JsonPropertyName("collections")]
            public List<DSpaceCollection> Collections { get; set; }

            [JsonPropertyName("items")]
            public List<DSpaceCollection> Items { get; set; }

            [JsonPropertyName("indexableObject")]
            public DSpaceCollection ItemOfCollection { get; set; }

            public EmbeddedObject()
            {
                Collections = [];
                Items = [];
                ItemOfCollection = new();
            }
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(DSpaceCollectionsResponse))]
    [JsonSerializable(typeof(EmbeddedObject))]
    [JsonSerializable(typeof(DSpaceCollection))]
    [JsonSerializable(typeof(List<DSpaceCollection>))]
    [JsonSerializable(typeof(DSpacePagination))]
    public partial class DSpaceResponseContext : JsonSerializerContext { }

}

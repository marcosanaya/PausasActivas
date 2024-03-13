using ConsoleForLinux.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleForLinux.Helpers
{
    public class DSpaceCollectionsResponse
    {
        [JsonPropertyName("_embedded")]
        public EmbeddedObject Embedded { get; set; }

        //[JsonPropertyName("_links")]
        //public object Links { get; set; }

        [JsonPropertyName("page")]
        public DSpacePaginationResponse Pagination { get; set; }

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

            [JsonPropertyName("objects")]
            public List<DSpaceCollection> ItemsOfCollections { get; set; }

            public EmbeddedObject()
            {
                Collections = [];
                Items = [];
                ItemsOfCollections = [];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases
{
    /// <summary>
    /// Se utiliza por ejemplo así: https://dspacepre.patrimonionacional.es/server/api/core/items?Pagination=1&size=20
    /// </summary>
    public class DSpacePaginationResponse
    {
        [JsonPropertyName("size")]
        public int Size;

        [JsonPropertyName("totalElements")]
        public int TotalElements;

        [JsonPropertyName("totalPages")]
        public int TotalPages;

        [JsonPropertyName("number")]
        public int CurrentPage;

        public DSpacePaginationResponse()
        {
            //Size = TotalElements = TotalPages = CurrentPage = 50;
        }
    }
}

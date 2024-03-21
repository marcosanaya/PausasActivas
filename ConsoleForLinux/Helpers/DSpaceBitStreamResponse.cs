using ConsoleForLinux.Business;
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
    public class DSpaceBitStreamResponse
    {
        [JsonPropertyName("_embedded")]
        public EmbeddedBitStream Embedded { get; set; }

        [JsonPropertyName("page")]
        public DSpacePagination Pagination { get; set; }

        public DSpaceBitStreamResponse()
        {
            Embedded = new();
            Pagination = new();
        }
    }

    public class EmbeddedBitStream
    {
        [JsonPropertyName("bitstreamformats")]
        public List<BitStreamFormat> BitStreamFormats { get; set; }

        public EmbeddedBitStream()
        {
            BitStreamFormats = [];
        }
    }

    [JsonSerializable(typeof(DSpaceBitStreamResponse))]
    [JsonSerializable(typeof(EmbeddedBitStream))]
    [JsonSerializable(typeof(BitStreamFormat))]
    [JsonSerializable(typeof(List<BitStreamFormat>))]
    [JsonSerializable(typeof(List<string>))]
    [JsonSerializable(typeof(DSpacePagination))]
    public partial class BitStreamResponseContext : JsonSerializerContext { }

}

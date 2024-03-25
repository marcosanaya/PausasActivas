using System.Text.Json.Serialization;

namespace ConsoleForLinux.Clases.Manifest
{
    public class Sequence
    {
        [JsonPropertyName("@id")]
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("@type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("canvases")]
        public List<Canvas> Canvases { get; set; } = [];

        public Sequence() 
        { 
        }
    }

    public class Canvas
    {
        [JsonPropertyName("@id")]
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("@type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("metadata")]
        public List<string> Metadata{ get; set; } = [];

        [JsonPropertyName("thumbnail")]
        public Thumbnail? Thumb { get; set; }


        [JsonPropertyName("images")]
        public List<ImageManifest> Images { get; set; } = [];

        public Canvas()
        {
            
        }
    }

    public class ImageManifest
    {
        [JsonPropertyName("@id")]
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("@type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("@context")]
        public string Context { get; set; } = string.Empty;

        [JsonPropertyName("motivation")]
        public string Motivation { get; set; } = string.Empty;

        [JsonPropertyName("on")]
        public string On { get; set; } = string.Empty;

        [JsonPropertyName("resource")]
        public Resource? Resources { get; set; }

        public ImageManifest()
        {
            
        }
    }

    public class Resource
    {
        [JsonPropertyName("@id")]
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("@type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("service")]
        public ServicesBase Service { get; set; } = new();

        [JsonPropertyName("format")]
        public string Format { get; set; } = string.Empty;

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        public Resource()
        {
            
        }
    }
}
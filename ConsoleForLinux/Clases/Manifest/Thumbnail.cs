using System.Text.Json.Serialization;

namespace ConsoleForLinux.Clases.Manifest
{
    public class Thumbnail
    {
        private ConstantsMetada? metada;

        [JsonPropertyName("@id")]
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("service")]
        public ServicesThumbnail Service { get; set; } = new();

        [JsonPropertyName("format")]
        public string Format{ get; set; } = string.Empty;

        public Thumbnail(ImageResource fileInfo, ProcessParams param)
        {
            metada = new(param);

            ID = metada.GetIIIFURLThumbnail(fileInfo.PhysicalImage.FullName);
            Service.ID = metada.GetIIIFURLThumbnail(fileInfo.PhysicalImage.FullName);
            Format = fileInfo.MimeFormat;
        }
    }

    public class ServicesBase
    {
        [JsonPropertyName("@id")]
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("@context")]
        public string Context { get; set; } = string.Empty;

        [JsonPropertyName("profile")]
        public string Profile { get; set; } = string.Empty;

        public ServicesBase()
        {
            Context = ConstantsMetada.ThumbnailServiceContext;
            Profile = ConstantsMetada.ThumbnailServiceProfile;
        }
    }
    public class ServicesThumbnail: ServicesBase
    {
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; } = string.Empty;

        public ServicesThumbnail()
        {
            Context = ConstantsMetada.ThumbnailServiceContext;
            Profile = ConstantsMetada.ThumbnailServiceProfile;
            Protocol = ConstantsMetada.ThumbnailServiceProtocol;
        }
    }
}
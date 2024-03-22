using System.Text.Json.Serialization;

namespace ConsoleForLinux.Clases.Manifest
{
    /*
 "@id": "http://192.168.0.20:8182/iiif/2/af26a741-7542-4ecb-bbce-2bcb0a68c86d/full/90,/0/default.jpg",
        "service": {
            "@context": "http://iiif.io/api/image/2/context.json",
            "@id": "http://192.168.0.20:8182/iiif/2/af26a741-7542-4ecb-bbce-2bcb0a68c86d",
            "profile": "http://iiif.io/api/image/2/level0.json",
            "protocol": "http://iiif.io/api/image"
        },
        "format": "image/jpeg"     
     */
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
            Service.ID = metada.IIIFURLBase(fileInfo.PhysicalImage.FullName);
            Format = fileInfo.MimeFormat;
        }
    }

    public class ServicesThumbnail
    {
        [JsonPropertyName("@id")]
        public string ID { get; set; } = string.Empty;

        [JsonPropertyName("@context")]
        public string Context { get; set; } = string.Empty;

        [JsonPropertyName("profile")]
        public string Profile { get; set; } = string.Empty;

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; } = string.Empty ;

        public ServicesThumbnail()
        {
            Context = ConstantsMetada.ThumbnailServiceContext;
            Profile = ConstantsMetada.ThumbnailServiceProfile;
            Protocol = ConstantsMetada.ThumbnailServiceProtocol;
        }
    }
}
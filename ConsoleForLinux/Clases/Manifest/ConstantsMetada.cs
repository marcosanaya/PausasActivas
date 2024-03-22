using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleForLinux.Clases.Manifest
{
    public class ConstantsMetada
    {
        public static string ManifestContext = @"http://iiif.io/api/presentation/2/context.json";
        public static string ManifestType = "sc:Manifest";
        public static string SequenceType = "sc:Sequence";
        public static string CanvasType = "sc:Canvas";
        public static string ImageType = "oa:Annotation";
        public static string ResourceType = "dctypes:Image";

        public static string ImageMotivation = "sc:painting";

        public static string ThumbnailServiceContext = "http://iiif.io/api/image/2/context.json";
        public static string ThumbnailServiceProfile = "http://iiif.io/api/image/2/level0.json";
        public static string ThumbnailServiceProtocol = "http://iiif.io/api/image";

        public static string ThumbnailURLSufix = "/full/90,/0/default";
        public static string ImageURLSufix = "/full/full/0/default";

        public static string PathSeparator = "%2F";
        private static readonly List<Tuple<string, string>> metadataManifest =
        [
            new Tuple<string, string>("dc.title","Título"),
            new Tuple<string, string>("dc.creator","Autores")
        ];

        private readonly ProcessParams parametros;

        public string IIIFURLBase(string pathandfilename)
        {
            string pathbase = parametros.ResourcePath;

            string result = pathandfilename[pathbase.Length..]
                .Replace("/", PathSeparator)
                .Replace(@"\", PathSeparator);

            result = (result[..3].Equals(PathSeparator)) ? result[3..] : result;
            result = string.Concat(parametros.IIIFServer, result);
            return result;
        }

        public ConstantsMetada(ProcessParams param)
        {
            this.parametros = param;
        }

        public string GetContextID(string uUID)
        {
            return string.Concat(parametros.ManifestServer, uUID,".json");
        }

        public string GetIIIFURLImage(string pathandfilename)
        {
            string result = string.Concat(IIIFURLBase(pathandfilename), ImageURLSufix, pathandfilename.Substring(pathandfilename.Length - 4, 4));
            return result;
        }

        public string GetIIIFURLThumbnail(string pathandfilename)
        {
            string result = string.Concat(IIIFURLBase(pathandfilename), ThumbnailURLSufix, pathandfilename.Substring(pathandfilename.Length-4,4));
            return result;
        }

        public static List<Metadata> GetMetadataManifest(DSpaceCollection dspaceitem)
        {
            List<Metadata> result = [];

            foreach (var item in metadataManifest)
            {
                var founded = dspaceitem.Metadata.Where(m=>m.Name.Contains(item.Item1)).ToList();
                StringBuilder sb = new();
                foreach (var dato in founded)
                    sb.Append(dato.Value);

                result.Add(new()
                {
                    label = item.Item2,
                    value = sb.ToString()
                });
            }
            return result;
        }

        public List<Sequence> GetSequencesManifest(List<ImageResource> imageFiles)
        {
            List<Sequence> result = [];

            List<Canvas> canvas = [];

            foreach (var item in imageFiles)
            {
                string imagen = item.PhysicalImage.Name;

                Canvas newCanvas = new()
                {
                    ID = string.Concat(parametros.ManifestServer, imagen),
                    Type = CanvasType,
                    Label = imagen,
                    Height = item.Height,
                    Width = item.Width,
                    Thumb = new(item, parametros)                    
                };

                Resource resource = new()
                {
                    ID = GetIIIFURLImage(item.PhysicalImage.FullName),
                    Type = ResourceType,
                    Format = item.MimeFormat,
                    Service = new()
                    {
                        ID = GetIIIFURLImage(item.PhysicalImage.FullName)
                    }
                };

                ImageManifest itemImage = new()
                {
                    Type = ImageType,
                    Context = ThumbnailServiceContext,
                    Motivation = ImageMotivation,
                    On = newCanvas.ID,
                    ID = GetIIIFURLImage(item.PhysicalImage.FullName),
                    Resources = resource
                };

                newCanvas.Images.Add(itemImage);
                canvas.Add(newCanvas);
            }

            result.Add(new()
            {
                ID = string.Concat(parametros.ManifestServer, "seq"),
                Type = SequenceType,
                Canvases = canvas
            });

            return result;
        }

        public string? GetContextSting()
        {
            throw new NotImplementedException();
        }

    }
}

using ConsoleForLinux.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.Json;
using ConsoleForLinux.Helpers;

namespace ConsoleForLinux.Business
{
    public sealed class FileResourcesManager: TimeProcess
    {
        private static FileResourcesManager? _instance;
        private static string HashDBFileName = "HashDBFile.json";

        private ProcessParams config;
        private List<PDFPathFile> PDFPathFiles = [];
        private List<string> ImageExtensions = [];
        //private List<string> ImageExtensions = ["aces", "apng", "avci", "avcs", "avif", "bmp", "cgm", "dicom-rle", "dpx", "emf", "example", "fits", "g3fax", "gif", "heic", "heic-sequence", "heif", "heif-sequence", "hej2k", "hsj2", "ief", "j2c", "jls", "jp2", "jpeg", "jph", "jphc", "jpm", "jpx", "jxl", "jxr", "jxrA", "jxrS", "jxs", "jxsc", "jxsi", "jxss", "ktx", "ktx2", "naplps", "png", "prs.btif", "prs.pti", "pwg-raster", "svg+xml", "t38", "tiff", "tiff-fx", "vnd.adobe.photoshop", "vnd.airzip.accelerator.azv", "vnd.cns.inf2", "vnd.dece.graphic", "vnd.djvu", "vnd.dwg", "vnd.dxf", "vnd.dvb.subtitle", "vnd.fastbidsheet", "vnd.fpx", "vnd.fst", "vnd.fujixerox.edmics-mmr", "vnd.fujixerox.edmics-rlc", "vnd.globalgraphics.pgb", "vnd.microsoft.icon", "vnd.mix", "vnd.ms-modi", "vnd.mozilla.apng", "vnd.net-fpx", "vnd.pco.b16", "vnd.radiance", "vnd.sealed.png", "vnd.sealedmedia.softseal.gif", "vnd.sealedmedia.softseal.jpg", "vnd.svf", "vnd.tencent.tap", "vnd.valve.source.texture", "vnd.wap.wbmp", "vnd.xiff", "vnd.zbrush.pcx", "webp", "wmf", "x-emf", "x-wmf","tif"];

        private FileResourcesManager()
        {
            config = new();
        }

        public static FileResourcesManager GetInstance()
        {
            _instance ??= new();
            return _instance;
        }
        
        public void SetParamProcess(ProcessParams infoParams)
        {
            if (infoParams is not null)
            {
                config = infoParams;
            }
        }

        public string GetResourcePath()
        {
            return config.ResourcePath;
        }

        public void SearchPDFFiles(string path)
        {
            DirectoryInfo currentDirectory = new(path);
            
            Console.WriteLine("Starting scanning PDF files in {0} folders...", currentDirectory.GetDirectories().Length);

            var pdffilelist = currentDirectory.GetFiles("*.pdf", SearchOption.AllDirectories);
            foreach (var item in pdffilelist)
            {
                var filesAtDirectory = item.Directory ?? new("");
                var resourcesList = new List<FileInfo>();

                foreach (var itemFile in filesAtDirectory.GetFiles())
                    if (itemFile.Extension.Length >= 3)
                        if (ImageExtensions.Contains(itemFile.Extension[1..]))
                            resourcesList.Add(itemFile);

                if (resourcesList.Count > 0)
                    PDFPathFiles.Add(new PDFPathFile
                    {
                        File = item,
                        HashResources = string.Empty,
                        HasImageFiles = false,
                        ImageFiles = resourcesList
                    });
            }

            Console.WriteLine("Founded {0} PDF files ", PDFPathFiles.Count);
        }

        public void CalculatingHasFromFileSystem()
        {
            string imagesSeed = string.Empty;

            foreach (var item in PDFPathFiles)
            {
                foreach (var img in item.ImageFiles)
                    imagesSeed += string.Concat(img.Name, img.Length.ToString(), img.CreationTime, img.LastWriteTime);

                string itemSeed = string.Concat(item.File.Name, item.File.Length.ToString(), item.File.CreationTime, item.File.LastWriteTime, imagesSeed);
                byte[] seedBytes = Encoding.UTF8.GetBytes(itemSeed);
                StringBuilder stringBuilder = new();

                seedBytes = MD5.HashData(seedBytes);
                seedBytes.ToList().ForEach(x => stringBuilder.Append(x.ToString("x2")));
                item.HashResources = stringBuilder.ToString();
                item.HasImageFiles = item.ImageFiles.Count > 0;
            }
            /*Write Files Scanned*/
        }

        public List<PDFPathFile> GetPDFPathFiles()
        {
            return IsStillRunning() ? [] : PDFPathFiles;
        }

        public HashResourcesDB GetHashDB()
        {
            bool existsHasDB = File.Exists(HashDBFileName);

            HashResourcesDB result = new();

            if(existsHasDB)
            {
                List<string> rawlines;
                StringBuilder data = new();
                CustomSerializer serializer = new();

                rawlines = File.ReadAllLines(HashDBFileName).ToList() ?? [];
                rawlines.ForEach(x => data.AppendLine(x));

                try
                {
                    result = serializer.GetHasDBDeserialized(data.ToString());
                    data.Clear();
                }
                catch (Exception e)
                {
                    GenericsManager.PrintExceptionMessage(e);
                }
            }

            return result;
        }

        public void WriteHashDB(List<DSpaceItem> dspaceInfo)
        {
            HashResourcesDB data = new();
            var hashfiledbInfo = (from f in PDFPathFiles
                                select new ResourceItem()
                                {
                                    CountImages = f.ImageFiles.Count,
                                    HashResources= f.HashResources,
                                    HasImageFiles = f.HasImageFiles,
                                    PDFFileName = f.File.Name,
                                }).ToList();
            try
            {
                if (hashfiledbInfo.Count > 0 && dspaceInfo.Count > 0)
                {
                    data.ResourcesFiles = hashfiledbInfo;
                    data.DSpaceItems = dspaceInfo;

                    var info = JsonSerializer.Serialize(data);
                    File.WriteAllText(HashDBFileName, info.ToString());
                }
                else
                    Console.WriteLine("*** No se escribió el HashDB ***");
            }
            catch (Exception e)
            {
                Console.Clear();
                GenericsManager.PrintExceptionMessage(e);
            }
        }

        public void SetImageExtensions(List<string> extensions)
        {
            this.ImageExtensions = extensions;
        }
    }
}

using ConsoleForLinux.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Business
{
    public sealed class FileResourcesManager
    {
        private static FileResourcesManager? _instance;

        private ProcessParams config;
        private List<PDFPathFile> pDFPathFiles = [];

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
            var listFolders = Directory.GetDirectories(path);
            Console.WriteLine("Starting scanning PDF files in {0} folders...", listFolders.Length);
            //foreach (var folder in listFolders)
            //{
            //    SearchPDFFiles(folder);
            //}

            DirectoryInfo currentDirectory = new DirectoryInfo(path);
            var pdffilelist = currentDirectory.GetFiles("*.pdf", SearchOption.AllDirectories);
            foreach (var item in pdffilelist)
            {
                //item.
                Console.WriteLine(item);
            }

            Console.WriteLine(path);
        }

        private void ScanFolders(string resourcePath)
        {
            
        }
    }
}

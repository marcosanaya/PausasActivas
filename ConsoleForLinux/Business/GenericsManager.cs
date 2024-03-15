using ConsoleForLinux.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Business
{
    public class GenericsManager
    {
        private static GenericsManager? _instance;

        private ProcessParams config;

        private GenericsManager()
        {
            config = new();
        }

        public static GenericsManager GetInstance()
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

        public static void PrintExceptionMessage(Exception exception)
        {
            Console.WriteLine($"{exception.Message}");
            Console.WriteLine();
            Console.WriteLine(exception.StackTrace);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PausasActivas.Business
{
    public sealed class PausasActivasApp
    {
        private readonly Dictionary<string, string> keyValuePairs = [];

        private static PausasActivasApp? _instance;

        private PausasActivasApp()
        {
            NameValueCollection nameValueCollection = ConfigurationManager.AppSettings is null ? [] : ConfigurationManager.AppSettings;

            if (nameValueCollection != null)
            {
                foreach (var pair in nameValueCollection)
                {
                    if (pair != null)
                    {
                        string clave = pair.ToString() ?? string.Empty;
                        string valor = nameValueCollection[clave]?? string.Empty;
                        
                        keyValuePairs.Add(clave, valor);
                    }
                }
            }
        }
        public static PausasActivasApp GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PausasActivasApp();
            }
            return _instance;
        }

        public byte GetValueinByte(string clave)
        {
            byte result = 0;

            if (keyValuePairs.TryGetValue(clave, out var valor))
            {
                result = byte.Parse(valor);
            }
            return result;
        }
        public int GetValueinInt(string clave)
        {
            int result = 0;

            if (keyValuePairs.TryGetValue(clave, out var valor))
            {
                result = int.Parse(valor);
            }
            return result;
        }
    }
}

/*
 public sealed class Singleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Singleton _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.
        public void someBusinessLogic()
        {
            // ...
        }
    }
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForLinux.Clases.Manifest
{
    public class ConstantsMetada
    {
        public static string ManifestContext = @"http://iiif.io/api/presentation/2/context.json";
        public static string ManifestType = "sc:Manifest";


        private readonly ProcessParams parametros;

        public ConstantsMetada(ProcessParams param)
        {
            this.parametros = param;
        }

        internal string GetContextID(string uUID)
        {
            return string.Concat(parametros.ManifestServer, uUID);
        }

        internal string? GetContextSting()
        {
            throw new NotImplementedException();
        }
    }
}

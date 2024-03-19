using ConsoleForLinux.Business;
using ConsoleForLinux.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleForLinux.Helpers
{
    public class HashResourcesDB
    {
        public List<HashResourceItem> ResourcesFiles { get; set; }

        public List<DSpaceItem> ResourcesDSpace { get; set; }

        public HashResourcesDB()
        {
            ResourcesFiles = [];
            ResourcesDSpace = [];
        }

        public HashDBDataStatus GetDataStatus()
        {
            HashDBDataStatus result= HashDBDataStatus.NoData;

            if (ResourcesFiles.Count == 0 && ResourcesDSpace.Count == 0)
                return HashDBDataStatus.NoData;

            if (ResourcesFiles.Count >0 && ResourcesDSpace.Count > 0)
                return HashDBDataStatus.DataComplete;

            if(ResourcesFiles.Count>0)
                result = HashDBDataStatus.ResourceData;
            
            if(ResourcesDSpace.Count>0)
                result = HashDBDataStatus.DSpaceData;

            return result;
        }
    }

    public class HashResourceItem
    {
        public string PDFFileName { get; set; } = string.Empty;
        public string HashResources { get; set; } = string.Empty;
        public bool HasImageFiles { get; set; }
        public int CountImages { get; set; }
    }

    [JsonSerializable(typeof(HashResourcesDB))]
    [JsonSerializable(typeof(List<HashResourceItem>))]
    [JsonSerializable(typeof(List<DSpaceItem>))]
    [JsonSerializable(typeof(string))]
    public partial class HashResourceDBContext : JsonSerializerContext { }
}

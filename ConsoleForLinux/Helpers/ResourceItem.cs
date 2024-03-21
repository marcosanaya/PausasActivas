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
        public List<ResourceItem> ResourcesFiles { get; set; }

        public List<DSpaceItem> DSpaceItems { get; set; }

        public HashResourcesDB()
        {
            ResourcesFiles = [];
            DSpaceItems = [];
        }

        public HashDBDataStatus GetDataStatus()
        {
            HashDBDataStatus result= HashDBDataStatus.NoData;

            if (ResourcesFiles.Count == 0 && DSpaceItems.Count == 0)
                return HashDBDataStatus.NoData;

            if (ResourcesFiles.Count >0 && DSpaceItems.Count > 0)
                return HashDBDataStatus.DataComplete;

            if(ResourcesFiles.Count>0)
                result = HashDBDataStatus.ResourceData;
            
            if(DSpaceItems.Count>0)
                result = HashDBDataStatus.DSpaceData;

            return result;
        }
    }

    public class ResourceItem
    {
        public string PDFFileName { get; set; } = string.Empty;
        public string HashResources { get; set; } = string.Empty;
        public bool HasImageFiles { get; set; }
        public int CountImages { get; set; }
    }

    [JsonSerializable(typeof(HashResourcesDB))]
    [JsonSerializable(typeof(List<ResourceItem>))]
    [JsonSerializable(typeof(List<DSpaceItem>))]
    [JsonSerializable(typeof(string))]
    public partial class HashResourceDBContext : JsonSerializerContext { }
}

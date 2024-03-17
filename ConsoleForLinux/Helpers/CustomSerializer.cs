using ConsoleForLinux.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleForLinux.Helpers
{
    public class CustomSerializer
    {
        public DSpaceCollectionsResponse GetObjectSimpleDeserialized(string data)
        {
            DSpaceCollectionsResponse result = JsonSerializer.Deserialize<DSpaceCollectionsResponse>(data, DSpaceResponseContext.Default.DSpaceCollectionsResponse) ?? new();

            return result;
        }

        public DSpaceCollectionsResponse GetObjectPagedDeserialized(string data)
        {
            DSpaceCollectionsResponse result = new();

            result = JsonSerializer.Deserialize<DSpaceCollectionsResponse>(data, DSpaceResponseContext.Default.DSpaceCollectionsResponse) ?? new();

            var dataDetail = JsonDocument.Parse(data).RootElement.GetProperty("page");
            result.Pagination.TotalElements = int.Parse(dataDetail.GetProperty("totalElements").ToString());
            result.Pagination.TotalPages = int.Parse(dataDetail.GetProperty("totalPages").ToString());
            result.Pagination.CurrentPage = int.Parse(dataDetail.GetProperty("number").ToString());

            return result;
        }

        public DSpaceCollectionsResponse GetSearchResulObjectDeserialized(string data)
        {
            DSpaceCollectionsResponse result = new();
            var tmp = JsonDocument.Parse(data).RootElement.GetProperty("_embedded");

            var objectsIterator = tmp.GetProperty("objects").EnumerateArray();
            List<DSpaceCollection> items = [];

            foreach (var obj in objectsIterator)
            {
                var valueItem = obj.GetProperty("_embedded").GetProperty("indexableObject");
                var objectID = valueItem.GetProperty("id");
                var metas = valueItem.GetProperty("metadata");

                DSpaceCollection dspaceItem = JsonSerializer.Deserialize<DSpaceCollection>(valueItem.ToString(), DSpaceCollectionContext.Default.DSpaceCollection) ?? new();

                foreach (var meta in metas.EnumerateObject())
                    foreach (var item in meta.Value.EnumerateArray())
                        dspaceItem.Metadata.Add(new DSpaceMetadataDefinition
                        {
                            Name = meta.Name,
                            Value = item.ToString()
                        });
                items.Add(dspaceItem);
            }

            result.Embedded.Items = items;

            return result;
        }
    }
}

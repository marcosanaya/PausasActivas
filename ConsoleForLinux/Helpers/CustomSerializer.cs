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
            var tmp = JsonDocument.Parse(data).RootElement.GetProperty("_embedded").GetProperty("objects");
            var newtmp = JsonSerializer.Deserialize<List<DSpaceCollectionsResponse>>(tmp) ?? new();
            newtmp.ForEach(d => result.Embedded.Items.Add(d.Embedded.ItemOfCollection));
            
            return result;
        }
    }
}

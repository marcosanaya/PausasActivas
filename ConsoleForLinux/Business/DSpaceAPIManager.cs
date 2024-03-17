using ConsoleForLinux.Clases;
using ConsoleForLinux.Helpers;
using System.Text.Json;

namespace ConsoleForLinux.Business
{
    public sealed class DSpaceAPIManager: TimeProcess
    {
        private const string msgFailedToLogin = "Failed to login in DSpace, please check credential used.";
        private const string AuthorizationHeaderName = "Authorization";
        private static DSpaceAPIManager? _instance;

        private readonly string urlBase = "server/api/";
        private readonly string urlLogin = "authn/login";
        private readonly string urlCollections = "core/collections/";
        private readonly string urlItemsByCollection = "discover/search/objects/?scope=";
        private readonly string urlItems= "core/items";
        private readonly string urlBitstreams = "core/bundles/";
        private readonly string XSRFTOKENName = "DSPACE-XSRF-TOKEN";
        
        private readonly HttpClientHandler handler;
        private readonly GenericsManager exceptionManager;

        private DSpaceAPIManager()
        {
            exceptionManager = GenericsManager.GetInstance();
            config = new();
            handler = new()
            {
                UseProxy = false
            };
        }

        private string URLRequestPagination = string.Empty;
        private string XSRFTOKENValue = string.Empty;
        private string Token = string.Empty;
        private ProcessParams config;
        private List<string> DSpaceCollectionsIDList = [];
        private List<string> DSpaceItemsIDList = [];

        private DSpaceCollectionsResponse ItemsFromCollections = new();

        public static DSpaceAPIManager GetInstance()
        {
            _instance ??= new();
            return _instance;
        }

        public void SetParamProcess(ProcessParams infoParams)
        {
            if (infoParams is not null)
                config = infoParams;
        }

        public string RequestXSRFTOKEN()
        {
            string result = string.Empty;
            
            HttpRequestMessage request = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(string.Concat(config.Host, urlBase, urlLogin)),
            };

            HttpClient client = new(handler);

            try
            {
                var response = client.Send(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK
                    || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    result = response.Headers.FirstOrDefault(x => x.Key.Equals(XSRFTOKENName)).Value.FirstOrDefault() ?? string.Empty;
                    XSRFTOKENValue = result;
                }
                Console.WriteLine(XSRFTOKENValue);
            }
            catch (Exception e)
            {
                GenericsManager.PrintExceptionMessage(e);
                Environment.Exit(0);
            }

            return result;
        }

        public string GetRequestedXSRFTOKEN()
        { return XSRFTOKENValue; }

        public string GetRequestedAuthorizationToken()
        { return Token; }

        public string MakeLogin()
        {
            string result = string.Empty;
            HttpClient client = new(handler);

            var body = new MultipartFormDataContent
            {
                { new StringContent(config.User), "user" },
                { new StringContent(config.Password), "password" }
            };

            HttpRequestMessage request = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(string.Concat(config.Host, urlBase, urlLogin)),
                Content = body
            };
            request.Headers.Add("X-XSRF-TOKEN", XSRFTOKENValue);
            request.Headers.Add("Cookie", string.Concat("DSPACE-XSRF-COOKIE=", XSRFTOKENValue));

            try
            {
                var response = client.Send(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    result = response.Headers.FirstOrDefault(x => x.Key.Equals(AuthorizationHeaderName)).Value.FirstOrDefault() ?? string.Empty;
                else
                    Console.WriteLine(msgFailedToLogin);
            }
            catch (Exception)
            {
                Console.WriteLine("It can not reach url, enter new URL in Host variable in ParamConfiguration.json file.");
                Environment.Exit(0);
            }

            if (result.Length == 0)
            {
                Console.WriteLine(msgFailedToLogin);
                Environment.Exit(0);
            }
            else
                Console.WriteLine("Login successfull.");
            Token = result.Substring(7);

            return result;
        }

        public DSpaceCollectionsResponse GetResponseProcessed(RequestType requestType)
        {
            DSpaceCollectionsResponse result = new();
            DSpaceCollectionsResponse tmpresult = new();
            HttpClient client = new(handler);

            URLRequestPagination = string.Concat(config.Host, urlBase, requestType == RequestType.ForDSpaceCollections ? urlCollections : urlItems);

            HttpRequestMessage request = MakeRequestMessage(URLRequestPagination);

            try
            {
                var response = client.Send(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var body = response.Content.ReadAsStringAsync().Result;
                    CustomSerializer serializer = new();
                    result = serializer.GetObjectPagedDeserialized(body);

                    Console.WriteLine("Reading {0} elements", result.Pagination.TotalElements);

                    for (int i = 1; i < result.Pagination.TotalPages; i++)
                    {
                        string pageparams = "?page=" + i.ToString() + "&size=20";
                        var urlrequest = string.Concat(URLRequestPagination, pageparams);
                        
                        request = MakeRequestMessage(urlrequest);
                        response = client.Send(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            body = response.Content.ReadAsStringAsync().Result;
                            tmpresult = serializer.GetObjectSimpleDeserialized(body);
                        }
                        if (requestType == RequestType.ForDSpaceCollections)
                            result.Embedded.Collections.AddRange(tmpresult.Embedded.Collections);
                        else
                            result.Embedded.Items.AddRange(tmpresult.Embedded.Items);
                    }
                    result.Embedded.Collections.ForEach(x => DSpaceCollectionsIDList.Add(x.ID));
                    result.Embedded.Items.ForEach(x => DSpaceItemsIDList.Add(x.ID));
                }
            }
            catch (Exception e)
            {
                GenericsManager.PrintExceptionMessage(e);
                Console.WriteLine("It can not get collections list.");
                Environment.Exit(0);
            }

            return result;
        }

        private HttpRequestMessage MakeRequestMessage(string url)
        {
            HttpRequestMessage result = new()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(string.Concat(url)),
            };

            result.Headers.Add(AuthorizationHeaderName, Token);

            return result;
        }

        public void ValidateFilterCollections()
        {
            var filterCollections = new List<string>();

            if (config.Collections != null && config.Collections.Count > 0)
                foreach (var item in config.Collections)
                    if (!DSpaceCollectionsIDList.Exists(x => x.Equals(item)))
                        Console.WriteLine("Collection {0} not found in DSpace {1}", item, config.Host);
                    else
                        filterCollections.Add(item);
            DSpaceCollectionsIDList = filterCollections;
        }

        public void ProcessesItemsCollectionsValidated()
        {
            DSpaceCollectionsResponse tmpresult = new();
            HttpClient client = new(handler);

            foreach (var item in config.Collections)
            {
                URLRequestPagination = string.Concat(config.Host, urlBase, urlItemsByCollection, item);

                HttpRequestMessage request = MakeRequestMessage(URLRequestPagination);

                try
                {
                    var response = client.Send(request);
                    CustomSerializer serializer = new CustomSerializer();

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var body = response.Content.ReadAsStringAsync().Result;
                        var data = JsonDocument.Parse(body).RootElement.GetProperty("_embedded").GetProperty("searchResult").ToString();

                        ItemsFromCollections = serializer.GetObjectPagedDeserialized(data);
                        Console.WriteLine("Reading {0} elements", ItemsFromCollections.Pagination.TotalElements);
                        ItemsFromCollections = serializer.GetSearchResulObjectDeserialized(data);

                        for (int i = 1; i < ItemsFromCollections.Pagination.TotalPages; i++)
                        {
                            string pageparams = "&page=" + i.ToString();
                            var urlrequest = string.Concat(URLRequestPagination, pageparams);

                            request = MakeRequestMessage(urlrequest);
                            response = client.Send(request);
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                body = response.Content.ReadAsStringAsync().Result;
                                tmpresult = serializer.GetSearchResulObjectDeserialized(data);
                                ItemsFromCollections.Embedded.Items.AddRange(tmpresult.Embedded.Items);
                            }
                        }
                        ItemsFromCollections.Embedded.Items.ForEach(x => DSpaceItemsIDList.Add(x.ID));
                    }
                }
                catch (Exception e)
                {
                    GenericsManager.PrintExceptionMessage(e);

                    Console.WriteLine("It can not get collections list.");
                    Environment.Exit(0);
                }
            }
        }

        internal void AttacheImageFromFiles(List<PDFPathFile> filesScanned)
        {
            throw new NotImplementedException();
        }
    }
}
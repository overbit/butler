using System.Net.Http;
using System.Threading.Tasks;
using alfred_api.Config;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace alfred_api.Services
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient httpClient;
        private readonly UrlsConfig urls;

        public SearchService(HttpClient httpClient, IOptions<UrlsConfig> config)
        {
            this.httpClient = httpClient;
            this.urls = config.Value;
        }

        public async Task<SearchResultPocModel> GetFacets(SearchQuery model)
        {
            var facetUrl = urls.Search + UrlsConfig.SearchOperations.GetList();

            var responseMessage = await httpClient.SendAsync(RequestMessage(facetUrl, HttpMethod.Get, model));
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            return !string.IsNullOrEmpty(responseContent) ? JsonConvert.DeserializeObject<SearchResultPocModel>(responseContent) : null;
        }

        public async Task<SearchResultPocModel> GetProducts(SearchQuery model)
        {
            var facetUrl = urls.Search + UrlsConfig.SearchOperations.GetList();

            var responseMessage = await httpClient.SendAsync(RequestMessage(facetUrl, HttpMethod.Get, model));
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            return !string.IsNullOrEmpty(responseContent) ? JsonConvert.DeserializeObject<SearchResultPocModel>(responseContent) : null; 
        }

        private static HttpRequestMessage RequestMessage(string url, HttpMethod method, SearchQuery content)
        {
            return new HttpRequestMessage(method, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content))
            };

        }
    }
}

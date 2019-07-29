using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using alfred_api.Config;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;
using Microsoft.AspNetCore.WebUtilities;
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

        public async Task<SearchResultPocModel> GetFacets(SearchQuery sq)
        {
            var facetUrl = urls.Search + UrlsConfig.SearchOperations.GetList();

            var url = QueryHelpers.AddQueryString(facetUrl, GetQueryParams(sq));

            var responseMessage = await httpClient.GetAsync(url);
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            var res = !string.IsNullOrEmpty(responseContent) ? JsonConvert.DeserializeObject<SearchResultPocModel>(responseContent) : null;

            if (res == null) return new SearchResultPocModel();

            foreach (var fc in res.FacetCategories)
            {
                fc.Facet.Name = fc.Facet.Name.Replace("Facet", string.Empty);
            }
            return res;
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
            var request = new HttpRequestMessage(method, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content))
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return request;
        }

        private static Dictionary<string, string> GetQueryParams(SearchQuery queryObj)
        {
            var queryStringParams = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(queryObj.TargetName))
            {
                queryStringParams.Add("selected.targetName", queryObj.TargetName);
            }
            if (!string.IsNullOrWhiteSpace(queryObj.Application))
            {
                queryStringParams.Add("selected.application", queryObj.Application);
            }
            if (!string.IsNullOrWhiteSpace(queryObj.Reactivity))
            {
                queryStringParams.Add("selected.reactivity", queryObj.Reactivity);
            }
            if (!string.IsNullOrWhiteSpace(queryObj.HostSpecies))
            {
                queryStringParams.Add("selected.hostSpecies", queryObj.HostSpecies);
            }

            return queryStringParams;
        }
    }
}

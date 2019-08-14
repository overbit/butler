using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using alfred_api.Config;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public async Task<SearchResultPocModel> GetProducts(SearchQuery sq)
        {
            var facetUrl = urls.Search + UrlsConfig.SearchOperations.GetList();

            var url = QueryHelpers.AddQueryString(facetUrl, GetQueryParams(sq));

            var responseMessage = await httpClient.GetAsync(url);
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            return !string.IsNullOrEmpty(responseContent) ? JsonConvert.DeserializeObject<SearchResultPocModel>(responseContent) : null; 
        }
        
        private static Dictionary<string, string> GetQueryParams(SearchQuery queryObj)
        {
            var json = JsonConvert.SerializeObject(queryObj);
            var jsObj = (JObject)JsonConvert.DeserializeObject(json);
            var queryStringParams = jsObj.Children().Cast<JProperty>()
                .Where(property => !string.IsNullOrWhiteSpace(property.Value.ToString()))
                .Select(jp => new Tuple<string,string>( jp.Name, jp.Value.ToString()));
            return queryStringParams.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
        }
    }
}

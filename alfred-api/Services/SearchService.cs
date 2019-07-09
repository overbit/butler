using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<FacetCategory>> GetFacets(SearchQuery model)
        {
            var data = await httpClient.GetStringAsync(urls.Search + UrlsConfig.SearchOperations.GetList());

            var facets = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<SearchResultPOCModel>(data).FacetCategories : null;

            return facets;
        }

        public async Task<IList<Product>> GetProducts(SearchQuery model)
        {
            var data = await httpClient.GetStringAsync(urls.Search + UrlsConfig.SearchOperations.GetList());

            var products = !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<SearchResultPOCModel>(data).Products.ToList() : null;

            return products;
        }
    }
}

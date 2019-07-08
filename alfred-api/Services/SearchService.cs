using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;

namespace alfred_api.Services
{
    public class SearchService : ISearchService
    {
        public async Task<IList<FacetCategory>> GetFacets(SearchQuery model)
        {

            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetProducts(SearchQuery model)
        {
            throw new NotImplementedException();
        }
    }
}

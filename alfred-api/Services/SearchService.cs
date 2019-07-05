using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using alfred_api.Model.Request.Search;
using alfred_api.Model.Response.Search;

namespace alfred_api.Services
{
    public class SearchService : ISearchService
    {
        public Task<IList<FacetCategory>> GetFacets(SearchQuery model)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> GetProducts(SearchQuery model)
        {
            throw new NotImplementedException();
        }
    }
}

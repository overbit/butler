using System.Collections.Generic;
using System.Threading.Tasks;
using alfred_api.Model.Request.Search;
using alfred_api.Model.Response.Search;

namespace alfred_api.Services
{
    internal interface ISearchService
    {
        Task<IList<FacetCategory>> GetFacets(SearchQuery model);

        Task<IList<Product>> GetProducts(SearchQuery model);
    }
}
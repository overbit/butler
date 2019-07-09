using System.Collections.Generic;
using System.Threading.Tasks;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;

namespace alfred_api.Services
{
    public interface ISearchService
    {
        Task<IList<FacetCategory>> GetFacets(SearchQuery model);

        Task<IList<Product>> GetProducts(SearchQuery model);
    }
}
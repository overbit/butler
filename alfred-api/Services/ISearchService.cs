using System.Threading.Tasks;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;

namespace alfred_api.Services
{
    public interface ISearchService
    {
        Task<SearchResultPocModel> GetFacets(SearchQuery model);

        Task<SearchResultPocModel> GetProducts(SearchQuery model);
    }
}
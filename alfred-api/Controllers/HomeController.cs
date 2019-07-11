using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;
using alfred_api.Model.Dtos.Search.Request;
using alfred_api.Model.Dtos.Search.Response;
using alfred_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace alfred_api.Controllers
{
    [Route("api/alfred")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISearchService searchService;
        private readonly IMapper mapper;
        
        public HomeController(ISearchService searchService, IMapper mapper)
        {
            this.searchService = searchService;
            this.mapper = mapper;
        }


        [HttpGet("facet")]
        public async Task<ActionResult<string>> Facet(FacetQueryDto dto)
        {
            var facetRequired = dto.RequiredFacets;
            var searchQuery = mapper.Map<SearchQuery>((SearchQueryDto)dto);
            searchQuery.PageSize = 1;

            var searchResultModel = await searchService.GetFacets(searchQuery);

            var result = mapper.Map<List<FacetCategory>>(searchResultModel.FacetCategories);

            // TODO this should be handled by the service
            var filteredResult = result.Where(category =>
                facetRequired.Contains(category.Facet.Name.Replace("Facet", string.Empty)));

            return new JsonResult(filteredResult);
        }

        [HttpGet("product")]
        public async Task<ActionResult<string>> Product(SearchQueryDto dto)
        {
            var searchQuery = mapper.Map<SearchQuery>(dto);
            
            // TODO remove this workaround
            searchQuery.PageSize = 100000;

            var searchResultModel = await searchService.GetProducts(searchQuery);

            var result = mapper.Map<ProductsDto>(searchResultModel);

            return new JsonResult(result);
        }

        [HttpGet("")]
        public async Task<ActionResult> Test(bool appOnly = false)
        {
            var res = "Alfred at your service master Bruce";
//
//            if (!appOnly)
//            {
//                try
//                {
//                    await searchService.GetFacets(new );
//                }
//                catch
//                {
//
//                }
//            }

            return Content(res);
        }
    }
}
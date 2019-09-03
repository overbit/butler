using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alfred_api.Config;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Dtos.Search.Request;
using alfred_api.Model.Dtos.Search.Response;
using alfred_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace alfred_api.Controllers
{
    [Route("api/alfred")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISearchService searchService;
        private readonly IMapper mapper;

        // TODO Remove this - Only for testing
        private readonly UrlsConfig urls;

        public HomeController(ISearchService searchService, IMapper mapper, IOptions<UrlsConfig> config)
        {
            this.searchService = searchService;
            this.mapper = mapper;
            this.urls = config.Value;
        }


        [HttpPost("facet")]
        public async Task<ActionResult> Facet(SearchQueryDto dto)
        {
            var facetRequired = new[]{ "TargetName", "Application", "Reactivity", "HostSpecies" };
            var searchQuery = mapper.Map<SearchQuery>(dto);
            searchQuery.PageSize = 0;

            var searchResultModel = await searchService.GetFacets(searchQuery);

            var result = mapper.Map<List<FacetCategoryDto>>(searchResultModel.FacetCategories);

            // TODO this should be handled by the service
            var filteredResult = result
                        .Where(category => facetRequired.Contains(category.Name));

            return new JsonResult(filteredResult);
        }

        [HttpPost("product")]
        public async Task<ActionResult> Product(SearchQueryDto dto,[FromQuery] int size = 0, [FromQuery] int page = 1)
        {
            var searchQuery = mapper.Map<SearchQuery>(dto);

            // TODO refactor and protect load on search server
            searchQuery.PageSize = size;
            searchQuery.PageNumber = page;
            // TODO remove this workaround
            if (size == 0)
            {
                searchQuery.PageSize = 100000;
            }

            var searchResultModel = await searchService.GetProducts(searchQuery);
            
            var result = mapper.Map<ProductsDto>(searchResultModel);

            return new JsonResult(result);
        }

        [HttpGet("")]
        public ActionResult Test(bool appOnly = false)
        {
            var res = "Alfred at your service master Bruce";

            res += Environment.NewLine;
            res += "Connect to: ";
            res += urls.Search;

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
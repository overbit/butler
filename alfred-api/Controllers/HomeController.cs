using System.Threading.Tasks;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Dtos.Search.Request;
using alfred_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace alfred_api.Controllers
{
    [Route("api/alfred")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISearchService searchService;
        
        public HomeController(ISearchService searchService)
        {
            this.searchService = searchService;
        }


        [HttpGet("facet")]
        public async Task<ActionResult<string>> Facet(SearchQueryDto dto)
        {
            var searchQuery = MapTo(dto);

            var result = await searchService.GetFacets(searchQuery);

            return new JsonResult(result);
        }

        [HttpGet("product")]
        public async Task<ActionResult<string>> Product(SearchQueryDto dto)
        {
            var searchQuery = MapTo(dto);

            var result = await searchService.GetProducts(searchQuery);

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
        
        private SearchQuery MapTo(SearchQueryDto dto)
        {
            return new SearchQuery
            {
                TargetName = dto.TargetName,
                Application = dto.Application,
                Reactivity = dto.Reactivity,
                HostSpecies = dto.HostSpecies
            };
        }
    }
}
using System.Threading.Tasks;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Dtos.Search.Request;
using alfred_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace alfred_api.Controllers
{
    [Route("api/alfred/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISearchService searchService;
        
        public HomeController(ISearchService searchService)
        {
            this.searchService = searchService;
        }


        [HttpGet]
        public async Task<ActionResult<string>> Facet(SearchQueryDto dto)
        {
            var searchQuery = MapTo(dto);

            var result = await searchService.GetFacets(searchQuery);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<ActionResult<string>> Product(SearchQueryDto dto)
        {
            var searchQuery = MapTo(dto);

            var result = await searchService.GetProducts(searchQuery);

            return new JsonResult(result);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Content("X");
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
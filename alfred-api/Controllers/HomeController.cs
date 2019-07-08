using System.Net;
using System.Threading.Tasks;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Dtos.Search.Request;
using alfred_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace alfred_api.Controllers
{
//    [Route("api/[controller]")]
    [Route("api/alfred")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ISearchService searchService;
        private readonly IMapper mapper;

        private HomeController(ISearchService searchService, IMapper mapper)
        {
            this.searchService = searchService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetFacets(SearchQueryDto dto)
        {
            var searchQuery = mapper.Map<SearchQuery>(dto);

            var result = await searchService.GetFacets(searchQuery);

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetProducts(SearchQueryDto dto)
        {
            var searchQuery = mapper.Map<SearchQuery>(dto);

            var result = await searchService.GetProducts(searchQuery);

            return new JsonResult(result);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
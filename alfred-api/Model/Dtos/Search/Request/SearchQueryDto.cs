using Microsoft.AspNetCore.Mvc;

namespace alfred_api.Model.Dtos.Search.Request
{
    public class SearchQueryDto
    {
        [FromBody]
        public string Keyword { get; set; }
        [FromBody]
        public FacetsDto Facets { get; set; }
    }

    public class FacetsDto
    {
        [FromBody]
        public string TargetName { get; set; }
        [FromBody]
        public string Application { get; set; }
        [FromBody]
        public string Reactivity { get; set; }
        [FromBody]
        public string HostSpecies { get; set; }
    }
}
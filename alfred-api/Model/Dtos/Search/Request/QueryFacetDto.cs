using System.Collections.Generic;

namespace alfred_api.Model.Dtos.Search.Request
{
    public class FacetQueryDto : SearchQueryDto
    {
        public IList<string> RequiredFacets { get; set; }
    }
}
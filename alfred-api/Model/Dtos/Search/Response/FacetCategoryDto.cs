using System.Collections.Generic;

namespace alfred_api.Model.Dtos.Search.Response
{
    public class FacetCategoryDto
    {
        public string Name { get; set; }

        public IList<FacetInfoDto> Facets { get; set; }
    }
}
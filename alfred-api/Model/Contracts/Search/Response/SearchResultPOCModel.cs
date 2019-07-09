using System.Collections.Generic;

namespace alfred_api.Model.Contracts.Search.Response
{
    public class SearchResultPOCModel
    {
        public IList<FacetCategory> FacetCategories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}

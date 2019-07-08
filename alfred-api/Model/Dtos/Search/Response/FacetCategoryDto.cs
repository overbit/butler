namespace alfred_api.Model.Dtos.Search.Response
{
    public class FacetCategoryDto
    {
        public FacetDto FacetDto { get; set; }
        public FacetInfoDto[] FacetInfosDto { get; set; }
        public bool IsFiltered { get; set; }
        public FilterDto[] FiltersDto { get; set; }
        public string FilterValueAsString { get; set; }
        public int NoOfFacetsToBeSortedByCount { get; set; }
        public int NoOfFacetsToBeSortedByWeightage { get; set; }
        public object ParentFacets { get; set; }
        public object ChildrenFacets { get; set; }
        public SelectedFacetDto SelectedFacetDto { get; set; }
    }
}
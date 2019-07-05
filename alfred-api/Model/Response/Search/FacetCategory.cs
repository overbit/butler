namespace alfred_api.Model.Response.Search
{
    public class FacetCategory
    {
        public Facet Facet { get; set; }
        public FacetInfo[] FacetInfos { get; set; }
        public bool IsFiltered { get; set; }
        public Filter[] Filters { get; set; }
        public string FilterValueAsString { get; set; }
        public int NoOfFacetsToBeSortedByCount { get; set; }
        public int NoOfFacetsToBeSortedByWeightage { get; set; }
        public object ParentFacets { get; set; }
        public object ChildrenFacets { get; set; }
        public SelectedFacet SelectedFacet { get; set; }
    }
}
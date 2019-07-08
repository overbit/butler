namespace alfred_api.Model.Dtos.Search.Response
{
    public class FacetDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public string LogicalOperator { get; set; }
    }
}
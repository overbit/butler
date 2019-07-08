namespace alfred_api.Model.Contracts.Search.Response
{
    public class Facet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        public string LogicalOperator { get; set; }
    }
}
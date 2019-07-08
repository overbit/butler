namespace alfred_api.Model.Contracts.Search.Response
{
    public class FacetInfo
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public bool Selected { get; set; }
        public object Parent { get; set; }
        public int Position { get; set; }
        public string DisplayName { get; set; }
        public bool AppearSelected { get; set; }
        public bool HasChildren { get; set; }
        public bool IsRoot { get; set; }
    }
}
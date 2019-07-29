using System.ComponentModel;

namespace alfred_api.Model.Contracts.Search.Request
{
    public class SearchQuery
    {
        [Description("selected.targetName")]
        public string TargetName { get; set; }

        [Description("selected.application")]
        public string Application { get; set; }

        [Description("selected.hostSpecies")]
        public string Reactivity { get; set; }

        [Description("selected.reactivity")]
        public string HostSpecies { get; set; }

        [Description("PageSize")]
        public int PageSize { get; set; }
    }
}
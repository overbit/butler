using Newtonsoft.Json;

namespace alfred_api.Model.Request.Search
{
    public class SearchQuery
    {
        [JsonProperty("selected.targetName")]
        public string TargetName { get; set; }

        [JsonProperty("selected.application")]
        public string Application { get; set; }

        [JsonProperty("selected.hostSpecies")]
        public string Reactivity { get; set; }

        [JsonProperty("selected.reactivity")]
        public string HostSpecies { get; set; }
    }
}
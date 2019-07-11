﻿using Newtonsoft.Json;

namespace alfred_api.Model.Contracts.Search.Request
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

        [JsonProperty("PageSize")]
        public int PageSize { get; set; }
    }
}
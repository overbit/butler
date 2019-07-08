namespace alfred_api.Config
{
    public class UrlsConfig
    {
        public class SearchOperations
        {
            public static string Get() => "/products/";
        }

        public string Search { get; set; }

    }
}

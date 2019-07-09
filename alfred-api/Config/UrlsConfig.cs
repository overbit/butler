namespace alfred_api.Config
{
    public class UrlsConfig
    {
        public class SearchOperations
        {
            public static string GetList() => "/products/searchapi";
        }

        public string Search { get; set; }

    }
}

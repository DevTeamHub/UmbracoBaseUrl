using Umbraco.Web.Routing;

namespace DevTeam.UmbracoBaseUrl
{
    public static class UmbracoBaseUrlConfig
    {
        public static void Setup(string baseUrl)
        {
            BaseUrlProvider.SetBaseUrl(baseUrl);
            BaseUrlContentFinder.SetBaseUrl(baseUrl);
            UrlProviderResolver.Current.InsertTypeBefore<DefaultUrlProvider, BaseUrlProvider>();
            ContentFinderResolver.Current.InsertTypeBefore<ContentFinderByNotFoundHandlers, BaseUrlContentFinder>();
        }
    }
}

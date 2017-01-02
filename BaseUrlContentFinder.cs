using Umbraco.Core;
using Umbraco.Web.Routing;

namespace DevTeam.UmbracoBaseUrl
{
    public class BaseUrlContentFinder : ContentFinderByNiceUrl
    {
        private static string _baseUrl;

        public static void SetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public override bool TryFindContent(PublishedContentRequest docRequest)
        {
            string route;
            if (docRequest.HasDomain)
                route = docRequest.Domain.RootNodeId.ToString() + DomainHelper.PathRelativeToDomain(docRequest.DomainUri, docRequest.Uri.GetAbsolutePathDecoded());
            else
                route = docRequest.Uri.GetAbsolutePathDecoded();

            route = route.Replace($"/{_baseUrl}", string.Empty);

            if (string.IsNullOrEmpty(route))
                route = "/";

            var node = FindContent(docRequest, route);
            return node != null;
        }
    }
}
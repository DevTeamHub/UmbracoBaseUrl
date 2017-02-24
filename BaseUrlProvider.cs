using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace DevTeam.UmbracoBaseUrl
{
    public class BaseUrlProvider: IUrlProvider
    {
        private static string _baseUrl;

        public static void SetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public string GetUrl(UmbracoContext umbracoContext, int id, Uri current, UrlProviderMode mode)
        {
            var content = umbracoContext.ContentCache.GetById(id);
            if (content?.Parent == null) return $"/{_baseUrl}";
            return $"{content.Parent.Url}/{content.UrlName}";
        }

        public IEnumerable<string> GetOtherUrls(UmbracoContext umbracoContext, int id, Uri current)
        {
            return Enumerable.Empty<string>();
        }
    }
}
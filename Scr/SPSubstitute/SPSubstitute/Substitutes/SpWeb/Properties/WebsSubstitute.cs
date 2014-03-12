using System;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SPWeb.Properties
{
    public class WebsSubstitute : Map
    {
        private WebSubstitute _webSubstitute;

        public WebsSubstitute(WebSubstitute webSubstitute)
        {
            _webSubstitute = webSubstitute;
        }

        public WebSubstitute Add(string webUrl, string title, string description, uint lcid, string webTemplate,
            bool useUniquePermissions, bool bConvertIfThere)
        {
            _webSubstitute.WebsCollections[webUrl] = new WebSubstitute(Arg.Any());
            _webSubstitute.WebsCollections[webUrl].Shim = new ShimSPWeb();
            return _webSubstitute.WebsCollections[webUrl];
        }

        public override void MapObjectValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}

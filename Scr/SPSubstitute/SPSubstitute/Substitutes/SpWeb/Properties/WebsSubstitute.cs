using System;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SPWeb.Properties
{
    public class WebsSubstitute : Map
    {
        private readonly SPWebSubstitute _spWebSubstitute;

        public WebsSubstitute(SPWebSubstitute spWebSubstitute)
        {
            _spWebSubstitute = spWebSubstitute;
        }

        public SPWebSubstitute Add(string webUrl, string title, string description, uint lcid, string webTemplate,
            bool useUniquePermissions, bool bConvertIfThere)
        {
            _spWebSubstitute.WebsCollections[webUrl] = new SPWebSubstitute(Arg.Any());
            _spWebSubstitute.WebsCollections[webUrl].Shim = new ShimSPWeb();
            return _spWebSubstitute.WebsCollections[webUrl];
        }

        public override void MapObjectValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}

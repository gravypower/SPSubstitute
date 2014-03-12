using System;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpWeb.Properties
{
    public class WebsSubstitute : Map
    {
        private SpWebSubstitute _spWebSubstitute;

        public WebsSubstitute(SpWebSubstitute spWebSubstitute)
        {
            _spWebSubstitute = spWebSubstitute;
        }

        public SpWebSubstitute Add(string webUrl, string title, string description, uint lcid, string webTemplate,
            bool useUniquePermissions, bool bConvertIfThere)
        {
            _spWebSubstitute.WebsCollections[webUrl] = new SpWebSubstitute(Arg.Any());
            _spWebSubstitute.WebsCollections[webUrl].Shim = new ShimSPWeb();
            return _spWebSubstitute.WebsCollections[webUrl];
        }

        public override void MapObjectValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpWeb.Properties
{
    public class WebsSubstitute : Map
    {
        private SubstituteSpWeb _substituteSpWeb;

        public WebsSubstitute(SubstituteSpWeb substituteSpWeb)
        {
            _substituteSpWeb = substituteSpWeb;
        }

        public SubstituteSpWeb Add(string webUrl, string title, string description, uint lcid, string webTemplate,
            bool useUniquePermissions, bool bConvertIfThere)
        {
            _substituteSpWeb.WebsCollections[webUrl] = new SubstituteSpWeb(Arg.Any());
            _substituteSpWeb.WebsCollections[webUrl].Shim = new ShimSPWeb();
            return _substituteSpWeb.WebsCollections[webUrl];
        }

        public override void MapObjectValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}

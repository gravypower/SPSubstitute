using System;
using System.Collections.Generic;
using System.Linq;
using SPSubstitute.Substitutes.SPWeb.Collections;

namespace SPSubstitute.Substitutes.SPWeb.Properties
{
    using Microsoft.SharePoint.Fakes;

    public class WebsSubstitute
    {
        private readonly SPWebSubstitute _spWebSubstitute;

        public WebsSubstitute(SPWebSubstitute spWebSubstitute)
        {
            _spWebSubstitute = spWebSubstitute;
        }

        public SPWebSubstitute Add(string webUrl, string title, string description, uint lcid, string webTemplate,
            bool useUniquePermissions, bool bConvertIfThere)
        {
            _spWebSubstitute.WebsCollections[webUrl] = new SPWebSubstitute(Arg.Any()) {Shim = new ShimSPWeb()};
            return _spWebSubstitute.WebsCollections[webUrl];
        }

        public void Returns(IList<SPWebSubstitute> webs)
        {
            _spWebSubstitute.Actions.Add(delegate
            {
                _spWebSubstitute.Shim.WebsGet = () =>
                {
                    var shim = new ShimSPWebCollection();

                    var webTemplates = webs.Select(x => x.SpType);
                    shim.Bind(webTemplates);

                    shim.ItemGetInt32 = i => webs[i].SpType;

                    return shim;
                };
            });
        }

        public void Returns(WebsCollections websCollections)
        {
            _spWebSubstitute.Actions.Add(delegate
            {
                _spWebSubstitute.Shim.WebsGet = () =>
                {
                    var shim = new ShimSPWebCollection();

                    var webs = websCollections.SpWebs.Select(x => x.SpType);

                    shim.ItemGetInt32 = i => websCollections.SpWebs[i].SpType;

                    shim.Bind(webs);

                    return shim;
                };
            });
        }
    }
}

using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes.SPSite;
using SPSubstitute.Substitutes.SPWeb.Collections;
using SPSubstitute.Substitutes.SPWeb.Properties;

namespace SPSubstitute.Substitutes.SPWeb
{
    public class WebSubstitute : Substitute<ShimSPWeb, Microsoft.SharePoint.SPWeb>
    {
        public WebsCollections WebsCollections;

        public WebSubstitute()
            : this(Arg.Any())
        {
            var site = new SPSiteSubstitute(Arg.Any());
            site.OpenWeb().Returns(this);

            Shim.WebsGet = () =>
            {
                var shim = new ShimSPWebCollection();

                var webs = WebsCollections.SpWebs.Select(x => x.SpType);

                shim.ItemGetInt32 = i => WebsCollections.SpWebs[i].SpType;

                shim.Bind(webs);

                return shim;
            };
        }

        public WebSubstitute(Arg args)
        {
            WebsCollections = new WebsCollections();
            Webs = new WebsSubstitute(this);
        }

        public WebsSubstitute Webs;
    }
}

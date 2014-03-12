using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes.SpSite;
using SPSubstitute.Substitutes.SpWeb.Collections;
using SPSubstitute.Substitutes.SpWeb.Properties;

namespace SPSubstitute.Substitutes.SpWeb
{
    public class SpWebSubstitute : SpSubstitute<ShimSPWeb, SPWeb>
    {
        public WebsCollections WebsCollections;

        public SpWebSubstitute()
            : this(Arg.Any())
        {
            var site = new SpSiteSubstitute(Arg.Any());
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

        public SpWebSubstitute(Arg args)
        {
            WebsCollections = new WebsCollections();
            Webs = new WebsSubstitute(this);
        }

        public WebsSubstitute Webs;
    }
}

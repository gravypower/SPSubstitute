namespace SPSubstitute.Substitutes.SPWeb
{
    using System.Linq;
    using Microsoft.SharePoint.Fakes;
    using Microsoft.SharePoint;
    using SPSite;
    using Collections;
    using Properties;

    public class SPWebSubstitute : Substitute<ShimSPWeb, SPWeb>
    {
        public WebsCollections WebsCollections;

        public SPWebSubstitute()
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

        public SPWebSubstitute(Arg args)
        {
            WebsCollections = new WebsCollections();
            Webs = new WebsSubstitute(this);
        }

        public WebsSubstitute Webs;
    }
}

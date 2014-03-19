namespace SPSubstitute.Substitutes.SPWeb
{
    using Microsoft.SharePoint.Fakes;
    using Microsoft.SharePoint;
    using SPSite;
    using Collections;
    using Properties;

    public class SPWebSubstitute : Substitute<ShimSPWeb, SPWeb>
    {
        public WebsCollections WebsCollections;

        public SPWebSubstitute()
            :this(null)
        {
        }

        public SPWebSubstitute(Arg args)
        {
            WebsCollections = new WebsCollections();
            Webs = new WebsSubstitute(this);

            if (args == null)
            {
                var site = new SPSiteSubstitute(Arg.Any());
                site.OpenWeb().Returns(this);
            }

            Webs.Returns(WebsCollections);
        }

        public WebsSubstitute Webs;

        public static SPWebSubstitute CreateSPWebSubstituteForReturn()
        {
            return new SPWebSubstitute(Arg.Any());
        }
    }
}

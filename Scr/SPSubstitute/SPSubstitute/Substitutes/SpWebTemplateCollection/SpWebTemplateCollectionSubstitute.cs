namespace SPSubstitute.Substitutes.SpWebTemplateCollection
{
    using System.Collections.Generic;
    using SpWebTemplate;

    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;

    using SPSite;

    public class SPWebTemplateCollectionSubstitute : Substitute<ShimSPWebTemplateCollection, SPWebTemplateCollection>
    {
        public SPWebTemplateCollectionSubstitute()
        {
            Shim = new ShimSPWebTemplateCollection();
        }

        public void Returns(List<SPWebTemplateSubstitute> webTemplates)
        {
            var site = new SPSiteSubstitute(Arg.Any());
            site.WebTemplates(Arg.Any()).Returns(webTemplates);
        }
    }
}

namespace SPSubstitute.Substitutes.SpWebTemplateCollection
{
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;

    using SPSite;

    public class SPWebTemplateCollectionSubstitute : Substitute<ShimSPWebTemplateCollection, SPWebTemplateCollection>, IMap
    {
        public SPWebTemplateCollectionSubstitute(SPWebTemplateCollection webTemplateCollection)
        {
            Shim = new ShimSPWebTemplateCollection(webTemplateCollection);
        }

        public SPWebTemplateCollectionSubstitute()
        {
            Shim = new ShimSPWebTemplateCollection();
        }

        public void MapObjectValue(object value)
        {
            var site = new SPSiteSubstitute(Arg.Any());
            site.WebTemplates(Arg.Any()).Returns(value);
        }
    }
}

namespace SPSubstitute.Substitutes.SpWebTemplateCollection
{
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;

    using SpSite;

    public class SpWebTemplateCollectionSubstitute : SpSubstitute<ShimSPWebTemplateCollection, SPWebTemplateCollection>, IMap
    {
        public SpWebTemplateCollectionSubstitute(SPWebTemplateCollection webTemplateCollection)
        {
            Shim = new ShimSPWebTemplateCollection(webTemplateCollection);
        }

        public SpWebTemplateCollectionSubstitute()
        {
            Shim = new ShimSPWebTemplateCollection();
        }

        public void MapObjectValue(object value)
        {
            var site = new SpSiteSubstitute(Arg.Any());
            site.WebTemplates(Arg.Any()).Returns(value);
        }
    }
}

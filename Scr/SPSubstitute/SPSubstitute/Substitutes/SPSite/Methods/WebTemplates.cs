namespace SPSubstitute.Substitutes.SpSite.Methods
{
    using Microsoft.SharePoint.Fakes;

    public class WebTemplates : Map<ShimSPWebTemplateCollection>
    {
        public WebTemplates(SubstituteSpSite substituteSpSite)
            : base(substituteSpSite)
        {
        }

        protected override void MapValue(ShimSPSite site, ShimSPWebTemplateCollection value)
        {
            site.GetWebTemplatesUInt32 = u => value;
        }
    }
}

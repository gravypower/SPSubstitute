namespace SPSubstitute.Substitutes.SpSite.Properties
{
    using Microsoft.SharePoint.Fakes;

    public class PortalName : Map<string>
    {
        public PortalName(SubstituteSpSite substituteSpSite)
            : base(substituteSpSite)
        {
        }

        protected override void MapValue(ShimSPSite site, string value)
        {
            site.PortalNameGet = () => value;
        }
    }
}

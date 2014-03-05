using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes
{
    public class PortalName : Substitute<string>
    {
        public PortalName(SpSubstituteSite spSubstituteSite)
            : base(spSubstituteSite)
        {
        }

        protected override void Map(ShimSPSite site, string value)
        {
            site.PortalNameGet = () => value;
        }
    }
}

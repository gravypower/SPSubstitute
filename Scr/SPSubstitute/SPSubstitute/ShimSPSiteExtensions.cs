using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute
{
    public static class ShimSPSiteExtensions
    {
        public static void SetPortalName(this SPSite site, string portalName)
        {
            //site.PortalNameGet = () => portalName;
        }
    }
}

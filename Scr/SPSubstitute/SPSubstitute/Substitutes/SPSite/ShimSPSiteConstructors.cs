using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes.SpSite;

namespace SPSubstitute.Substitutes.SPSite
{
    public class ShimSpSiteConstructors
    {
        public static void Guid(SpSites sites)
        {
            ShimSPSite.ConstructorGuid = (site, guid) =>
            {
                var shimSite = new ShimSPSite(site);

                sites[guid].Shim = shimSite;

                foreach (var action in sites[guid].Actions)
                {
                    action.Invoke(shimSite);
                }
            };
        }

        public static void RequestUrl(SpSites sites)
        {
            ShimSPSite.ConstructorString = (site, requestUrl) =>
            {
                var shimSite = new ShimSPSite(site);

                sites[requestUrl].Shim = shimSite;

                foreach (var action in sites[requestUrl].Actions)
                {
                    action.Invoke(shimSite);
                }
            };
        }
    }
}

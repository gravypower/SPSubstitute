using Microsoft.SharePoint.Fakes;

namespace SPSubstitute
{
    public class ShimSpSiteConstructors
    {
        public static void Guid(ISpSites sites)
        {
            ShimSPSite.ConstructorGuid = (site, guid) =>
            {
                var shimSite = new ShimSPSite(site);

                foreach (var action in sites[guid].Actions)
                {
                    action.Invoke(shimSite);
                }

                sites[guid].ShimSpSite = shimSite;
            };
        }

        public static void RequestUrl(ISpSites sites)
        {
            ShimSPSite.ConstructorString = (site, requestUrl) =>
            {
                var shimSite = new ShimSPSite(site);

                foreach (var action in sites[requestUrl].Actions)
                {
                    action.Invoke(shimSite);
                }

                sites[requestUrl].ShimSpSite = shimSite;
            };
        }
    }
}

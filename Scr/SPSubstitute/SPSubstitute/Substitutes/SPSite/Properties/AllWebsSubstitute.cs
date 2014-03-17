namespace SPSubstitute.Substitutes.SPSite.Properties
{
    using System;
    using Microsoft.SharePoint.Fakes;
    using Shared.Webs;
    using Microsoft.SharePoint;

    public class AllWebsSubstitute : WebsBase<ShimSPSite, SPSite>
    {
        public AllWebsSubstitute(SPSiteSubstitute substitute)
            : base(substitute)
        {
        }

        public override void SetFakesDelegate(Func<ShimSPWebCollection> action)
        {
            Substitute.Shim.AllWebsGet = () => action.Invoke();
        }
    }
}

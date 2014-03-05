namespace SPSubstitute
{
    using System;

    using SPSubstitute.Substitutes.SpSite;

    public partial class SpSubstituteContext
    {
        public ISpSites Sites;

        public void SetUpForSpSite()
        {
            Sites = new SpSites();
            ShimSpSiteConstructors.Guid(Sites);
            ShimSpSiteConstructors.RequestUrl(Sites);
        }

        public SubstituteSpSite MockSpSite(Guid guid)
        {
            return Sites[guid];
        }

        public SubstituteSpSite MockSpSite(string requestUrl)
        {
            return Sites[requestUrl];
        }
    }
}

using System;
using Microsoft.QualityTools.Testing.Fakes;

namespace SPSubstitute
{
    public class SPSubstituteContext:IDisposable
    {
        protected IDisposable ShimContext;

        public ISpSites Sites;

        protected SPSubstituteContext(ISpSites sites)
        {
            ShimContext = ShimsContext.Create();
            Sites = sites;

            ShimSpSiteConstructors.Guid(Sites);
            ShimSpSiteConstructors.RequestUrl(Sites);
        }

        public SpSubstituteSite MockSite(Guid guid)
        {
            return Sites[guid];
        }

        public SpSubstituteSite MockSite(string requestUrl)
        {
            return Sites[requestUrl];
        }

        public void Dispose()
        {
            ShimContext.Dispose();
        }

        public static SPSubstituteContext NewContext()
        {
            return new SPSubstituteContext(new SpSites());
        } 
    }
}

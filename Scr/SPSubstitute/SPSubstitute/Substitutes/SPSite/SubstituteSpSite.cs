using System;
using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes.SpSite;
using SPSubstitute.Substitutes.SpSite.Methods;
using SPSubstitute.Substitutes.SpSite.Properties;

namespace SPSubstitute.Substitutes.SPSite
{
    public class SubstituteSpSite : SpSubstitute<ShimSPSite, Microsoft.SharePoint.SPSite>
    {
        public SpSites Sites;

        public PortalName PortalName;

        public SubstituteSpSite(Guid guid)
            : this()
        {
            Sites[guid] = this;
            ShimSpSiteConstructors.Guid(Sites);
        }

        public SubstituteSpSite(string requestUrl)
            : this()
        {
            Sites[requestUrl] = this;
            ShimSpSiteConstructors.RequestUrl(Sites);
        }

        private SubstituteSpSite()
        {
            Sites = new SpSites();
            PortalName = new PortalName(this);
        }

        public WebTemplates WebTemplates(uint lcid)
        {
            return new WebTemplates(this);
        }
    }
}

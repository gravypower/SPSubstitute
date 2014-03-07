using System;
using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes.SpSite;
using SPSubstitute.Substitutes.SpSite.Methods;
using SPSubstitute.Substitutes.SpSite.Properties;
using SPSubstitute.Substitutes.SpSite.Tasks;

namespace SPSubstitute.Substitutes.SPSite
{
    public class SubstituteSpSite : SpSubstitute<ShimSPSite, Microsoft.SharePoint.SPSite>
    {
        public Sites Sites;

        public PortalNameSubstitute PortalName;

        public SubstituteSpSite(Guid guid)
            : this()
        {
            Sites[guid] = this;
            new ConstructorGuid(this).Run();
        }

        public SubstituteSpSite(string requestUrl)
            : this()
        {
            Sites[requestUrl] = this;
            new ConstructorString(this).Run();
        }

        private SubstituteSpSite()
        {
            Sites = new Sites();
            this.PortalName = new PortalNameSubstitute(this);
        }

        public WebTemplatesSubstitute WebTemplates(uint lcid)
        {
            return new WebTemplatesSubstitute(this);
        }
    }
}

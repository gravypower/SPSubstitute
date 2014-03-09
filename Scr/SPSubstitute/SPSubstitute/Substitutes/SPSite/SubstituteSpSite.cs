using System;
using Microsoft.SharePoint.Fakes;

using SPSubstitute.Substitutes.SpSite.Methods;
using SPSubstitute.Substitutes.SpSite.Properties;
using SPSubstitute.Substitutes.SpSite.Tasks;

namespace SPSubstitute.Substitutes.SpSite
{
    using Microsoft.SharePoint;

    using SPSubstitute.Substitutes.SPSite.Collections;
    using SPSubstitute.Substitutes.SpSite.Collections;

    public class SubstituteSpSite : SpSubstitute<ShimSPSite, SPSite>
    {
        public Sites Sites;

        public WebTemplateCollections WebTemplateCollections;

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

        public SubstituteSpSite(Arg args)
            : this()
        {
            Sites[args] = this;
            new ConstructorString(this, args).Run();
        }

        private SubstituteSpSite()
        {
            Sites = new Sites();
            WebTemplateCollections = new WebTemplateCollections();
            this.PortalName = new PortalNameSubstitute(this);
        }

        public WebTemplatesSubstitute WebTemplates(uint lcid)
        {
            return new WebTemplatesSubstitute(this, lcid);
        }

        public WebTemplatesSubstitute WebTemplates(Arg args)
        {
            return new WebTemplatesSubstitute(this, args);
        }
    }
}

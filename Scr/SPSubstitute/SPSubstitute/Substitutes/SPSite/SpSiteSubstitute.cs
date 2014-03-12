using System;
using Microsoft.SharePoint.Fakes;

using SPSubstitute.Substitutes.SpSite.Methods;
using SPSubstitute.Substitutes.SpSite.Properties;
using SPSubstitute.Substitutes.SpSite.Tasks;

namespace SPSubstitute.Substitutes.SpSite
{
    using Microsoft.SharePoint;
    using Collections;

    public class SpSiteSubstitute : SpSubstitute<ShimSPSite, SPSite>
    {
        public Sites Sites;

        public WebTemplateCollections WebTemplateCollections;

        public PortalNameSubstitute PortalName;

        public SpSiteSubstitute(Guid guid)
            : this()
        {
            Sites[guid] = this;
            new ConstructorGuid(this).Run();
        }

        public SpSiteSubstitute(string requestUrl)
            : this()
        {
            Sites[requestUrl] = this;
            new ConstructorString(this).Run();
        }

        public SpSiteSubstitute(Arg args)
            : this()
        {
            Sites[args] = this;
            new ConstructorString(this, args).Run();
            new ConstructorGuid(this, args).Run();
        }

        private SpSiteSubstitute()
        {
            Sites = new Sites();
            WebTemplateCollections = new WebTemplateCollections();
            PortalName = new PortalNameSubstitute(this);
        }

        public WebTemplatesSubstitute WebTemplates(uint lcid)
        {
            return new WebTemplatesSubstitute(this, lcid);
        }

        public WebTemplatesSubstitute WebTemplates(Arg args)
        {
            return new WebTemplatesSubstitute(this, args);
        }

        public OpenWebSubstitute OpenWeb()
        {
            return new OpenWebSubstitute(this);
        }
    }
}

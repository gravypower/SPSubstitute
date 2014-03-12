using System;
using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes.SPSite.Methods;
using SPSubstitute.Substitutes.SPSite.Properties;
using SPSubstitute.Substitutes.SPSite.Tasks;

namespace SPSubstitute.Substitutes.SPSite
{
    using Microsoft.SharePoint;
    using Collections;

    public class SPSiteSubstitute : Substitute<ShimSPSite, SPSite>
    {
        public Sites Sites;

        public WebTemplateCollections WebTemplateCollections;

        public PortalNameSubstitute PortalName;

        public SPSiteSubstitute(Guid guid)
            : this()
        {
            Sites[guid] = this;
            new ConstructorGuid(this).Run();
        }

        public SPSiteSubstitute(string requestUrl)
            : this()
        {
            Sites[requestUrl] = this;
            new ConstructorString(this).Run();
        }

        public SPSiteSubstitute(Arg args)
            : this()
        {
            Sites[args] = this;
            new ConstructorString(this, args).Run();
            new ConstructorGuid(this, args).Run();
        }

        private SPSiteSubstitute()
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

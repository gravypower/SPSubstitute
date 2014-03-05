namespace SPSubstitute.Substitutes.SpSite
{
    using System;
    using System.Collections.Generic;

    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;

    using SPSubstitute.Substitutes.SpSite.Methods;
    using SPSubstitute.Substitutes.SpSite.Properties;

    public class SubstituteSpSite : Substitute<SPSite>
    {
        public ShimSPSite ShimSpSite;

        public SPSite SpSite
        {
            get { return this.ShimSpSite; }
        }

        public PortalName PortalName;

        public List<Action<ShimSPSite>> Actions; 

        public SubstituteSpSite()
        {
            this.PortalName = new PortalName(this);
            this.Actions = new List<Action<ShimSPSite>>();
        }

        public WebTemplates WebTemplates(uint lcid)
        {
            return new WebTemplates(this);
        }
    }
}

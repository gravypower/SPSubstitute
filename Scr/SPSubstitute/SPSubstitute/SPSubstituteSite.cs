using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes;

namespace SPSubstitute
{
    public class SpSubstituteSite
    {
        public ShimSPSite ShimSpSite;

        public SPSite SpSite
        {
            get { return ShimSpSite; }
        }
        public PortalName PortalName;

        public List<Action<ShimSPSite>> Actions; 

        public SpSubstituteSite(ShimSPSite shimSpSite)
        {
            ShimSpSite = shimSpSite;
            PortalName = new PortalName(this);
            Actions = new List<Action<ShimSPSite>>();
        }

        
    }
}

using Microsoft.SharePoint.Administration.Fakes;
using SPSubstitute.Substitutes.SPWebApplication.Properties;

namespace SPSubstitute.Substitutes.SPWebApplication
{
    public class SPWebApplicationSubstitute : Substitute<ShimSPWebApplication, Microsoft.SharePoint.Administration.SPWebApplication>
    {
        public SitesSubstitute Sites;

        public SPWebApplicationSubstitute()
        {
        }
    }
}

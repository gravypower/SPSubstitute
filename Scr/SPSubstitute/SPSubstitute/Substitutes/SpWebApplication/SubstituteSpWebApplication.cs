using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using SPSubstitute.Substitutes.SpWebApplication.Properties;

namespace SPSubstitute.Substitutes.SpWebApplication
{
    public class SubstituteSpWebApplication : SpSubstitute<ShimSPWebApplication, SPWebApplication>
    {
        public SitesSubstitute Sites;

        public SubstituteSpWebApplication()
        {
        }
    }
}

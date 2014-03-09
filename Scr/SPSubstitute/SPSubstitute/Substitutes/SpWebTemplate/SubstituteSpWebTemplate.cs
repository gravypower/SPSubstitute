using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpWebTemplate
{
    public class SubstituteSpWebTemplate:SpSubstitute<ShimSPWebTemplate, SPWebTemplate>
    {
        public SubstituteSpWebTemplate()
        {
            this.Invoke();
        }
    }
}

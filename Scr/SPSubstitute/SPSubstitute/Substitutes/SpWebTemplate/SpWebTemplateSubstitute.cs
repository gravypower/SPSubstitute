using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpWebTemplate
{
    public class SPWebTemplateSubstitute:Substitute<ShimSPWebTemplate, SPWebTemplate>
    {
        public SPWebTemplateSubstitute()
        {
            this.Invoke();
        }
    }
}

using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpWebTemplate
{
    public class SpWebTemplateSubstitute:SpSubstitute<ShimSPWebTemplate, SPWebTemplate>
    {
        public SpWebTemplateSubstitute()
        {
            this.Invoke();
        }
    }
}

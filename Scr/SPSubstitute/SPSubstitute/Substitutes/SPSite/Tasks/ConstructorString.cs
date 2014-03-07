using Microsoft.SharePoint.Fakes;
using SPSubstitute.Substitutes.SPSite;

namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    public class ConstructorString : Task<SubstituteSpSite>
    {
        public ConstructorString(SubstituteSpSite substitute) : base(substitute)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorString = (site, requestUrl) =>
            {
                var shimSite = new ShimSPSite(site);

                SpSubstitute.Sites[requestUrl].Shim = shimSite;

                foreach (var action in SpSubstitute.Sites[requestUrl].Actions)
                {
                    action.Invoke(shimSite);
                }
            };
        }
    }
}

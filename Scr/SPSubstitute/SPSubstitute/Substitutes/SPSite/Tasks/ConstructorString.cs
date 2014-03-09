using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    public class ConstructorString : Task<SubstituteSpSite>
    {
        public ConstructorString(SubstituteSpSite substitute)
            : base(substitute)
        {
        }

        public ConstructorString(SubstituteSpSite substitute, Arg args)
            : base(substitute, args)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorString = (site, requestUrl) =>
            {
                var shimSite = new ShimSPSite(site);

                if (Args != null)
                {
                    SpSubstitute.Sites[Args].Shim = shimSite;
                    foreach (var action in SpSubstitute.Sites[Args].Actions)
                    {
                        action.Invoke(shimSite);
                    }
                }
                else
                {
                    SpSubstitute.Sites[requestUrl].Shim = shimSite;

                    foreach (var action in SpSubstitute.Sites[requestUrl].Actions)
                    {
                        action.Invoke(shimSite);
                    }
                }
            };
        }
    }
}

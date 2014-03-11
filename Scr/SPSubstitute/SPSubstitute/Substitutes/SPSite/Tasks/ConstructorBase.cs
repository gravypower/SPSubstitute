using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint;

namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    public abstract class ConstructorBase<TConstructorArg> : Task<SubstituteSpSite>
    {
        protected ConstructorBase(SubstituteSpSite substitute, Arg args) : base(substitute, args)
        {
        }

        protected ConstructorBase(SubstituteSpSite substitute) : base(substitute)
        {
        }

        public void Run(SPSite site, TConstructorArg constructorArg)
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
                ConstructorArgRun(shimSite, constructorArg);
            }
        }

        public abstract void ConstructorArgRun(ShimSPSite site, TConstructorArg constructorArg);
    }
}

using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint;

namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    public abstract class ConstructorBase<TConstructorArg> : Task<SpSiteSubstitute>
    {
        protected ConstructorBase(SpSiteSubstitute spFarmSpSiteSubstitute, Arg args) : base(spFarmSpSiteSubstitute, args)
        {
        }

        protected ConstructorBase(SpSiteSubstitute spFarmSpSiteSubstitute) : base(spFarmSpSiteSubstitute)
        {
        }

        public void Run(SPSite site, TConstructorArg constructorArg)
        {
            var shimSite = new ShimSPSite(site);

            if (Args != null)
            {
                SpSpFarmSpSiteSubstitute.Sites[Args].Shim = shimSite;
                foreach (var action in SpSpFarmSpSiteSubstitute.Sites[Args].Actions)
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

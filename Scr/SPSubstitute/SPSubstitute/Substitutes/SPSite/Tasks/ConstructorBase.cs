namespace SPSubstitute.Substitutes.SPSite.Tasks
{
    using Microsoft.SharePoint.Fakes;

    public abstract class ConstructorBase<TConstructorArg> : Task<SPSiteSubstitute>
    {
        protected ConstructorBase(SPSiteSubstitute farmSpSiteSubstitute, Arg args) : base(farmSpSiteSubstitute, args)
        {
        }

        protected ConstructorBase(SPSiteSubstitute farmSpSiteSubstitute) : base(farmSpSiteSubstitute)
        {
        }

        public void Run(Microsoft.SharePoint.SPSite site, TConstructorArg constructorArg)
        {
            var shimSite = new ShimSPSite(site);

            if (Args != null)
            {
                FarmSpSiteSubstitute.Sites[Args].Shim = shimSite;
                foreach (var action in FarmSpSiteSubstitute.Sites[Args].Actions)
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

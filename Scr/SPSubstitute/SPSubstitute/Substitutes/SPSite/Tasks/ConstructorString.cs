namespace SPSubstitute.Substitutes.SPSite.Tasks
{
    using Microsoft.SharePoint.Fakes;

    public class ConstructorString : ConstructorBase<string>
    {
        public ConstructorString(SPSiteSubstitute farmSpSiteSubstitute)
            : base(farmSpSiteSubstitute)
        {
        }

        public ConstructorString(SPSiteSubstitute farmSpSiteSubstitute, Arg args)
            : base(farmSpSiteSubstitute, args)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorString = Run;
        }

        public override void ConstructorArgRun(ShimSPSite site, string constructorArg)
        {
            FarmSpSiteSubstitute.Sites[constructorArg].Shim = site;

            foreach (var action in FarmSpSiteSubstitute.Sites[constructorArg].Actions)
            {
                action.Invoke(site);
            }
        }
    }
}

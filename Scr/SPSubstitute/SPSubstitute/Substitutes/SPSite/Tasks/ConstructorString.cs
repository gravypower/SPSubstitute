namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    using Microsoft.SharePoint.Fakes;

    public class ConstructorString : ConstructorBase<string>
    {
        public ConstructorString(SpSiteSubstitute spFarmSpSiteSubstitute)
            : base(spFarmSpSiteSubstitute)
        {
        }

        public ConstructorString(SpSiteSubstitute spFarmSpSiteSubstitute, Arg args)
            : base(spFarmSpSiteSubstitute, args)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorString = Run;
        }

        public override void ConstructorArgRun(ShimSPSite site, string constructorArg)
        {
            SpSpFarmSpSiteSubstitute.Sites[constructorArg].Shim = site;

            foreach (var action in SpSpFarmSpSiteSubstitute.Sites[constructorArg].Actions)
            {
                action.Invoke(site);
            }
        }
    }
}

namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    using System;
    using Microsoft.SharePoint.Fakes;

    public class ConstructorGuid : ConstructorBase<Guid>
    {
        public ConstructorGuid(SpSiteSubstitute spFarmSpSiteSubstitute) 
            : base(spFarmSpSiteSubstitute)
        {
        }

        public ConstructorGuid(SpSiteSubstitute spFarmSpSiteSubstitute, Arg args)
            : base(spFarmSpSiteSubstitute, args)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorGuid = Run;
        }

        public override void ConstructorArgRun(ShimSPSite site, Guid constructorArg)
        {
            SpSpFarmSpSiteSubstitute.Sites[constructorArg].Shim = site;

            foreach (var action in SpSpFarmSpSiteSubstitute.Sites[constructorArg].Actions)
            {
                action.Invoke(site);
            }
        }
    }
}

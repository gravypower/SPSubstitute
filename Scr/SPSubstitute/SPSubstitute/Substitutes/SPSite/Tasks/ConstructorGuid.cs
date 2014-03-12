namespace SPSubstitute.Substitutes.SPSite.Tasks
{
    using System;
    using Microsoft.SharePoint.Fakes;

    public class ConstructorGuid : ConstructorBase<Guid>
    {
        public ConstructorGuid(SPSiteSubstitute farmSpSiteSubstitute) 
            : base(farmSpSiteSubstitute)
        {
        }

        public ConstructorGuid(SPSiteSubstitute farmSpSiteSubstitute, Arg args)
            : base(farmSpSiteSubstitute, args)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorGuid = Run;
        }

        public override void ConstructorArgRun(ShimSPSite site, Guid constructorArg)
        {
            FarmSpSiteSubstitute.Sites[constructorArg].Shim = site;

            foreach (var action in FarmSpSiteSubstitute.Sites[constructorArg].Actions)
            {
                action.Invoke(site);
            }
        }
    }
}

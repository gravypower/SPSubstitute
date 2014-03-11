namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    using System;
    using Microsoft.SharePoint.Fakes;

    public class ConstructorGuid : ConstructorBase<Guid>
    {
        public ConstructorGuid(SubstituteSpSite substitute) 
            : base(substitute)
        {
        }

        public ConstructorGuid(SubstituteSpSite substitute, Arg args)
            : base(substitute, args)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorGuid = Run;
        }

        public override void ConstructorArgRun(ShimSPSite site, Guid constructorArg)
        {
            SpSubstitute.Sites[constructorArg].Shim = site;

            foreach (var action in SpSubstitute.Sites[constructorArg].Actions)
            {
                action.Invoke(site);
            }
        }
    }
}

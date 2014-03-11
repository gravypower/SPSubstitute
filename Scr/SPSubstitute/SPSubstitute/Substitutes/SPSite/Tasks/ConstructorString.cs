namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    using Microsoft.SharePoint.Fakes;

    public class ConstructorString : ConstructorBase<string>
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
            ShimSPSite.ConstructorString = Run;
        }

        public override void ConstructorArgRun(ShimSPSite site, string constructorArg)
        {
            SpSubstitute.Sites[constructorArg].Shim = site;

            foreach (var action in SpSubstitute.Sites[constructorArg].Actions)
            {
                action.Invoke(site);
            }
        }
    }
}

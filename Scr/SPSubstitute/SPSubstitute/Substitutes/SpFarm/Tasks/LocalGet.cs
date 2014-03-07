using Microsoft.SharePoint.Administration.Fakes;

namespace SPSubstitute.Substitutes.SpFarm.Tasks
{
    public class LocalGet : Task<SubstituteSpFarm>
    {
        public LocalGet(SubstituteSpFarm substitute) : base(substitute)
        {
        }

        public override void Run()
        {
            ShimSPFarm.LocalGet = () =>
            {
                SpSubstitute.Shim = new ShimSPFarm();
                foreach (var action in SpSubstitute.Actions)
                {
                    action.Invoke(SpSubstitute.Shim);
                }

                return SpSubstitute.SpType;
            };
        }
    }
}

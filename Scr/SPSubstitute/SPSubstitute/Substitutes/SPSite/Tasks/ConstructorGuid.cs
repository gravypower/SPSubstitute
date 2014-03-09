using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpSite.Tasks
{
    public class ConstructorGuid : Task<SubstituteSpSite>
    {
        public ConstructorGuid(SubstituteSpSite substitute) : base(substitute)
        {
        }

        public override void Run()
        {
            ShimSPSite.ConstructorGuid = (site, guid) =>
            {
                var shimSite = new ShimSPSite(site);

                SpSubstitute.Sites[guid].Shim = shimSite;

                foreach (var action in SpSubstitute.Sites[guid].Actions)
                {
                    action.Invoke(shimSite);
                }
            };
        }
    }
}

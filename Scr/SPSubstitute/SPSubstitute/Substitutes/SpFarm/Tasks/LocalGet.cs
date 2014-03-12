using Microsoft.SharePoint.Administration.Fakes;

namespace SPSubstitute.Substitutes.SpFarm.Tasks
{
    public class LocalGet : Task<SpFarmSubstitute>
    {
        public LocalGet(SpFarmSubstitute spFarmSpSiteSubstitute) : base(spFarmSpSiteSubstitute)
        {
        }

        public override void Run()
        {
            ShimSPFarm.LocalGet = () =>
                {
                    this.SpSpFarmSpSiteSubstitute.Invoke();
                    return this.SpSpFarmSpSiteSubstitute.SpType;
                };
        }
    }
}

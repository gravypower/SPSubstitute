namespace SPSubstitute.Substitutes.SPFarm.Tasks
{
    using Microsoft.SharePoint.Administration.Fakes;

    public class LocalGet : Task<SPFarmSubstitute>
    {
        public LocalGet(SPFarmSubstitute farmSpSiteSubstitute) : base(farmSpSiteSubstitute)
        {
        }

        public override void Run()
        {
            ShimSPFarm.LocalGet = () =>
                {
                    this.FarmSpSiteSubstitute.Invoke();
                    return this.FarmSpSiteSubstitute.SpType;
                };
        }
    }
}

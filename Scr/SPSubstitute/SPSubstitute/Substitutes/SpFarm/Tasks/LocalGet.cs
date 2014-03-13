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
                foreach (var action in FarmSpSiteSubstitute.Actions)
                {
                    action.Invoke(FarmSpSiteSubstitute.Shim);
                }
                return FarmSpSiteSubstitute.SpType;
            };
        }
    }
}

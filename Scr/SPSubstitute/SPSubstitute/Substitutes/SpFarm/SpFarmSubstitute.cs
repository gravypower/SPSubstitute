

namespace SPSubstitute.Substitutes.SpFarm
{
    using System;
    using Microsoft.SharePoint.Administration;
    using Microsoft.SharePoint.Administration.Fakes;
    using Tasks;

    using Collections;
    using Methods;

    public class SpFarmSubstitute : SpSubstitute<ShimSPFarm, SPFarm>
    {
        public Objects Objects { get; private set; }

        public SpFarmSubstitute()
        {
            new LocalGet(this).Run();
            Objects = new Objects();
        }

        public GetObjectSubstitute GetObject(Guid id)
        {
            return new GetObjectSubstitute(this, id);
        }
    }
}

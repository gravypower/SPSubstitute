namespace SPSubstitute.Substitutes.SPFarm
{
    using System;
    using Microsoft.SharePoint.Administration;
    using Microsoft.SharePoint.Administration.Fakes;
    using Tasks;

    using Collections;
    using Methods;

    public class SPFarmSubstitute : Substitute<ShimSPFarm, SPFarm>
    {
        public Objects Objects { get; private set; }

        public SPFarmSubstitute()
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

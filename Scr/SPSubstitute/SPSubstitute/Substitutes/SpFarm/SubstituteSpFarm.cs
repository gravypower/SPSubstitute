using System;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using SPSubstitute.Substitutes.SpFarm.Methods;
using SPSubstitute.Substitutes.SpFarm.Tasks;

namespace SPSubstitute.Substitutes.SpFarm
{
    public class SubstituteSpFarm : SpSubstitute<ShimSPFarm, SPFarm>
    {
        public static SubstituteSpFarm Local { get; private set; }

        public Objects Objects { get; private set; }

        public SubstituteSpFarm()
        {
            Local = this;
            Objects = new Objects();
            new LocalGet(this).Run();
        }

        public GetObjectSubstitute GetObject(Guid id)
        {
            Objects[id] = new GetObjectSubstitute(this);
            return Objects[id];
        }
    }
}

using Microsoft.SharePoint.Administration;

namespace SPSubstitute.Substitutes.SpFarm.Methods
{
    using Microsoft.SharePoint.Administration.Fakes;

    public class GetObjectSubstitute : SpSubstitute<ShimSPPersistedObject, SPPersistedObject>, IMap
    {
        private readonly SubstituteSpFarm substituteSpFarm;

        public GetObjectSubstitute(SubstituteSpFarm substituteSpFarm)
        {
            this.substituteSpFarm = substituteSpFarm;
        }

        public void MapValue(object value)
        {
            substituteSpFarm.Actions.Add(site => DoMap(value));
        }

        public void DoMap(object value)
        {
            substituteSpFarm.Shim.GetObjectGuid = guid =>
                {
                    var spPersistedObject = (SPPersistedObject)value;
                    this.substituteSpFarm.Objects[spPersistedObject.Id].Shim = new ShimSPPersistedObject(spPersistedObject);
                    return this.substituteSpFarm.Objects[guid].SpType;
                };
        }

        public void MapValue(SpSubstitute value)
        {
            MapValue(value.GetValueForMapping());
        }
    }
}

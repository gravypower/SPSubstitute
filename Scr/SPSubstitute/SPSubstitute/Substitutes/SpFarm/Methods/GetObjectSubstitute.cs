using Microsoft.SharePoint.Administration;

namespace SPSubstitute.Substitutes.SpFarm.Methods
{
    public class GetObjectSubstitute : Map
    {
        private readonly SubstituteSpFarm substituteSpFarm;

        public GetObjectSubstitute(SubstituteSpFarm substituteSpFarm)
        {
            this.substituteSpFarm = substituteSpFarm;
        }

        public override void MapValue(object value)
        {
            substituteSpFarm.Shim.GetObjectGuid = guid => (SPPersistedObject)value;
        }

        public override void DoMap(object value)
        {
            substituteSpFarm.Actions.Add(site => DoMap(value));
        }
    }
}

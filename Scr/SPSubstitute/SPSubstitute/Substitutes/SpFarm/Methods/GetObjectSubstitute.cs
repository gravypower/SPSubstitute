namespace SPSubstitute.Substitutes.SpFarm.Methods
{
    using System;

    using Microsoft.SharePoint.Administration;

    using SPSubstitute.Substitutes.SpPersistedObject;

    public class GetObjectSubstitute : Map
    {
        private readonly SubstituteSpFarm substituteSpFarm;

        private readonly Guid objectId;

        public GetObjectSubstitute(SubstituteSpFarm substituteSpFarm, Guid objectId)
        {
            this.objectId = objectId;
            this.substituteSpFarm = substituteSpFarm;
        }

        public override void MapObjectValue(object value)
        {
            this.substituteSpFarm.Objects[objectId] = new SubstituteSpPersistedObject((SPPersistedObject)value);
            substituteSpFarm.Actions.Add(site => DoMap());
        }

        public void DoMap()
        {
            this.substituteSpFarm.Shim.GetObjectGuid = guid => this.substituteSpFarm.Objects[guid].SpType;
        }
    }
}

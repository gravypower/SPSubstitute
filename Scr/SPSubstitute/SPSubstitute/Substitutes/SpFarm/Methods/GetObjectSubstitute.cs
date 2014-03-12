using SPSubstitute.Substitutes.SPPersistedObject;

namespace SPSubstitute.Substitutes.SPFarm.Methods
{
    using System;

    using Microsoft.SharePoint.Administration;

    public class GetObjectSubstitute : Map
    {
        private readonly SPFarmSubstitute _farmSubstitute;

        private readonly Guid objectId;

        public GetObjectSubstitute(SPFarmSubstitute _farmSubstitute, Guid objectId)
        {
            this.objectId = objectId;
            this._farmSubstitute = _farmSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            this._farmSubstitute.Objects[objectId] = new SPPersistedObjectSubstitute((SPPersistedObject)value);
            _farmSubstitute.Actions.Add(site => DoMap());
        }

        public void DoMap()
        {
            this._farmSubstitute.Shim.GetObjectGuid = guid => this._farmSubstitute.Objects[guid].SpType;
        }
    }
}

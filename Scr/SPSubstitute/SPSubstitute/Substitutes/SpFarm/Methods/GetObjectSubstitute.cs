namespace SPSubstitute.Substitutes.SpFarm.Methods
{
    using System;

    using Microsoft.SharePoint.Administration;

    using SPSubstitute.Substitutes.SpPersistedObject;

    public class GetObjectSubstitute : Map
    {
        private readonly SpFarmSubstitute _spFarmSubstitute;

        private readonly Guid objectId;

        public GetObjectSubstitute(SpFarmSubstitute _spFarmSubstitute, Guid objectId)
        {
            this.objectId = objectId;
            this._spFarmSubstitute = _spFarmSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            this._spFarmSubstitute.Objects[objectId] = new SpPersistedObjectSubstitute((SPPersistedObject)value);
            _spFarmSubstitute.Actions.Add(site => DoMap());
        }

        public void DoMap()
        {
            this._spFarmSubstitute.Shim.GetObjectGuid = guid => this._spFarmSubstitute.Objects[guid].SpType;
        }
    }
}

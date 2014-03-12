using SPSubstitute.Substitutes.SPPersistedObject;

namespace SPSubstitute.Substitutes.SPFarm.Methods
{
    using System;

    using Microsoft.SharePoint.Administration;

    public class GetObjectSubstitute : Map
    {
        private readonly SPFarmSubstitute _farmSubstitute;

        private readonly Guid _objectId;

        public GetObjectSubstitute(SPFarmSubstitute farmSubstitute, Guid objectId)
        {
            _objectId = objectId;
            _farmSubstitute = farmSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            _farmSubstitute.Objects[_objectId] = new SPPersistedObjectSubstitute((SPPersistedObject)value);
            _farmSubstitute.Actions.Add(site => DoMap());
        }

        public void DoMap()
        {
            _farmSubstitute.Shim.GetObjectGuid = guid => _farmSubstitute.Objects[guid].SpType;
        }
    }
}

using SPSubstitute.Substitutes.SPWebApplication;

namespace SPSubstitute.Substitutes.SPFarm.Methods
{
    using System;
    using SPPersistedObject;

    public class GetObjectSubstitute
    {
        private readonly SPFarmSubstitute _farmSubstitute;

        private readonly Guid _objectId;

        public GetObjectSubstitute(SPFarmSubstitute farmSubstitute, Guid objectId)
        {
            _objectId = objectId;
            _farmSubstitute = farmSubstitute;
        }

        public void Returns(SPWebApplicationSubstitute spWebApplicationSubstitute)
        {
            _farmSubstitute.Objects[_objectId] = new SPPersistedObjectSubstitute(spWebApplicationSubstitute.SpType);
            _farmSubstitute.Actions.Add(site => DoMap());
        }

        public void DoMap()
        {
            _farmSubstitute.Shim.GetObjectGuid = guid => _farmSubstitute.Objects[guid].SpType;
        }
    }
}

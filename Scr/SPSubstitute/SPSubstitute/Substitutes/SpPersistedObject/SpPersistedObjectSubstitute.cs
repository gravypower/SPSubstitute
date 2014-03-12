using Microsoft.SharePoint.Administration.Fakes;

namespace SPSubstitute.Substitutes.SPPersistedObject
{
    public class SPPersistedObjectSubstitute : Substitute<ShimSPPersistedObject, Microsoft.SharePoint.Administration.SPPersistedObject>
    {
        public SPPersistedObjectSubstitute(Microsoft.SharePoint.Administration.SPPersistedObject persistedObject)
        {
            Shim = new ShimSPPersistedObject(persistedObject);
        }
    }
}

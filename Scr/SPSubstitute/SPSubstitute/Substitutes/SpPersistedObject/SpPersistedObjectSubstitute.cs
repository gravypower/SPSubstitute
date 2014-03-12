using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;

namespace SPSubstitute.Substitutes.SpPersistedObject
{
    public class SpPersistedObjectSubstitute : SpSubstitute<ShimSPPersistedObject, SPPersistedObject>
    {
        public SpPersistedObjectSubstitute(SPPersistedObject persistedObject)
        {
            Shim = new ShimSPPersistedObject(persistedObject);
        }
    }
}

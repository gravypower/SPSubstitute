using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;

namespace SPSubstitute.Substitutes.SpPersistedObject
{
    public class SubstituteSpPersistedObject : SpSubstitute<ShimSPPersistedObject, SPPersistedObject>
    {
        public SubstituteSpPersistedObject(SPPersistedObject persistedObject)
        {
            Shim = new ShimSPPersistedObject(persistedObject);
        }
    }
}

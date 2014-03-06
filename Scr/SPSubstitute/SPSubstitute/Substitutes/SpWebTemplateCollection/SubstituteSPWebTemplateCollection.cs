using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpWebTemplateCollection
{
    public class SubstituteSpWebTemplateCollection : SpSubstitute<ShimSPWebTemplateCollection, SPWebTemplateCollection>, IMap
    {
        public void MapValue(SpSubstitute value)
        {
            throw new System.NotImplementedException();
        }

        public void MapValue(object value)
        {
            throw new System.NotImplementedException();
        }

        public void DoMap(object value)
        {
            throw new System.NotImplementedException();
            //this.substituteSpSite.Shim.GetWebTemplatesUInt32 = u => (SPWebTemplateCollection)value;
        }
    }
}

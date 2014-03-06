using System.Collections.Generic;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute
{
    public abstract class SpSubstitute<TShim, TSpType> : SpSubstitute
        where TSpType : class
        where TShim : ShimBase<TSpType>, new ()
    {

        public TShim Shim;

        public TSpType SpType
        {
            get { return Shim; }
        }

        public List<System.Action<ShimSPSite>> Actions;

        protected SpSubstitute()
        {
            Actions = new List<System.Action<ShimSPSite>>();
        }

        public override object GetValueForMapping()
        {
            return SpType;
        }
    }

    public abstract class SpSubstitute
    {
        public abstract object GetValueForMapping();
    }
}

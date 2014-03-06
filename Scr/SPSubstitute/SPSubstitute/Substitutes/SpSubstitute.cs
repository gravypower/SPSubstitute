namespace SPSubstitute.Substitutes
{
    using System.Collections.Generic;

    using Microsoft.QualityTools.Testing.Fakes.Shims;
    using Microsoft.SharePoint.Fakes;

    public abstract class SpSubstitute<TShim, TSpType> : SpSubstitute
        where TSpType : class
        where TShim : ShimBase<TSpType>, new ()
    {

        public TShim Shim;

        public TSpType SpType
        {
            get { return this.Shim; }
        }

        public List<System.Action<ShimSPSite>> Actions;

        protected SpSubstitute()
        {
            this.Actions = new List<System.Action<ShimSPSite>>();
        }

        public override object GetValueForMapping()
        {
            return this.SpType;
        }
    }

    public abstract class SpSubstitute
    {
        public abstract object GetValueForMapping();
    }
}

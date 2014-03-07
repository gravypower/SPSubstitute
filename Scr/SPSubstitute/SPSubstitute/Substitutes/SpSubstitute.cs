namespace SPSubstitute.Substitutes
{
    using System.Collections.Generic;

    using Microsoft.QualityTools.Testing.Fakes.Shims;

    public abstract class SpSubstitute<TShim, TSpType> : SpSubstitute
        where TSpType : class
        where TShim : ShimBase<TSpType>, new ()
    {

        public TShim Shim { get; internal set; }

        public TSpType SpType
        {
            get { return this.Shim; }
        }

        internal List<System.Action<TShim>> Actions;

        protected SpSubstitute()
        {
            Actions = new List<System.Action<TShim>>();
        }

        internal override object GetValueForMapping()
        {
            return SpType;
        }
    }

    public abstract class SpSubstitute
    {
        internal abstract object GetValueForMapping();
    }
}

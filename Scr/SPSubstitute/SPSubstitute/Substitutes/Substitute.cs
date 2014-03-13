namespace SPSubstitute.Substitutes
{
    using System.Collections.Generic;

    using Microsoft.QualityTools.Testing.Fakes.Shims;

    public interface ISubstitute
    {
    }

    public abstract class Substitute<TShim, TSpType> : ISubstitute
        where TSpType : class
        where TShim : ShimBase<TSpType>, new()
    {

        public TShim Shim { get; internal set; }

        public TSpType SpType
        {
            get { return Shim; }
        }

        internal List<System.Action<TShim>> Actions;

        protected Substitute()
        {
            Actions = new List<System.Action<TShim>>();
            Shim = new TShim();
        }
    }
}

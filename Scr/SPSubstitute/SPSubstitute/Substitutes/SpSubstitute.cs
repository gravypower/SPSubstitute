namespace SPSubstitute.Substitutes
{
    using System.Collections.Generic;

    using Microsoft.QualityTools.Testing.Fakes.Shims;

    public abstract class SpSubstitute<TShim, TSpType> : SpSubstitute//, IMap
        where TSpType : class
        where TShim : ShimBase<TSpType>, new ()
    {

        public TShim Shim { get; internal set; }

        public TSpType SpType
        {
            get { return this.Shim; }
        }

        internal List<System.Action<TShim>> Actions;

        internal void Invoke()
        {
            if (Shim != null) return;

            Shim = new TShim();
            foreach (var action in Actions)
            {
                action.Invoke(Shim);
            }
        }

        protected SpSubstitute()
        {
            Actions = new List<System.Action<TShim>>();
        }

        internal override object GetValueForMapping()
        {
            Invoke();
            return SpType;
        }

        //public void MapValue(object value)
        //{
        //    throw new System.NotImplementedException();
        //}
    }

    public abstract class SpSubstitute
    {
        internal abstract object GetValueForMapping();
    }
}

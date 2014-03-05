using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes
{
    using SPSubstitute.Substitutes.SpSite;

    public abstract class Map<TSubstitute>
    {
        protected readonly SubstituteSpSite SubstituteSpSite;

        protected Map(SubstituteSpSite substituteSpSite)
        {
            this.SubstituteSpSite = substituteSpSite;
        }

        public void DoMap(TSubstitute value)
        {
            this.SubstituteSpSite.Actions.Add(site => MapValue(site, value));
        }

        protected abstract void MapValue(ShimSPSite site, TSubstitute value);
    }
    public abstract class Map
    {}
}

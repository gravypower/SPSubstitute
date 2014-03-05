using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes
{
    public abstract class Substitute<TSubstitute>
    {
        protected readonly SpSubstituteSite SpSubstituteSite;

        protected Substitute(SpSubstituteSite spSubstituteSite)
        {
            SpSubstituteSite = spSubstituteSite;
        }

        public void Returns(TSubstitute value)
        {
            SpSubstituteSite.Actions.Add(site => Map(site, value));
        }

        protected abstract void Map(ShimSPSite site, TSubstitute value);
    }
}

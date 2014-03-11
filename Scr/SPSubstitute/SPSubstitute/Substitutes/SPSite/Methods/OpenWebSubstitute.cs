using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpSite.Methods
{
    public class OpenWebSubstitute : Map
    {
        private readonly SubstituteSpSite _substituteSpSite;

        public OpenWebSubstitute(SubstituteSpSite substituteSpSite)
        {
            _substituteSpSite = substituteSpSite;
        }

        public override void MapObjectValue(object value)
        {
            _substituteSpSite.Shim = new ShimSPSite();

            _substituteSpSite.Actions.Add(
                site =>
                {
                    _substituteSpSite.Shim.OpenWeb = () => (SPWeb) value;
                });
        }
    }
}

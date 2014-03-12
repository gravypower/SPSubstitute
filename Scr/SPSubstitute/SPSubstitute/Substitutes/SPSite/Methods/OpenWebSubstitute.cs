using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpSite.Methods
{
    public class OpenWebSubstitute : Map
    {
        private readonly SpSiteSubstitute _spSiteSubstitute;

        public OpenWebSubstitute(SpSiteSubstitute spSiteSubstitute)
        {
            _spSiteSubstitute = spSiteSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            _spSiteSubstitute.Shim = new ShimSPSite();

            _spSiteSubstitute.Actions.Add(
                site =>
                {
                    _spSiteSubstitute.Shim.OpenWeb = () => (SPWeb) value;
                });
        }
    }
}

namespace SPSubstitute.Substitutes.SPSite.Methods
{
    using Microsoft.SharePoint.Fakes;

    public class OpenWebSubstitute : Map
    {
        private readonly SPSiteSubstitute _spSiteSubstitute;

        public OpenWebSubstitute(SPSiteSubstitute _spSiteSubstitute)
        {
            this._spSiteSubstitute = _spSiteSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            _spSiteSubstitute.Shim = new ShimSPSite();

            _spSiteSubstitute.Actions.Add(
                site =>
                {
                    _spSiteSubstitute.Shim.OpenWeb = () => (Microsoft.SharePoint.SPWeb) value;
                });
        }
    }
}

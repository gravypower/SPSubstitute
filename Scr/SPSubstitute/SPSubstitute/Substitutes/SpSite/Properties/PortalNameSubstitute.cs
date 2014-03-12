namespace SPSubstitute.Substitutes.SPSite.Properties
{
    public class PortalNameSubstitute : Map
    {
        private readonly SPSiteSubstitute _spSiteSubstitute;

        public string Value { get; set; }

        public PortalNameSubstitute(SPSiteSubstitute _spSiteSubstitute)
        {
            this._spSiteSubstitute = _spSiteSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            this._spSiteSubstitute.Actions.Add(site => DoMap(value));
            
        }

        public void DoMap(object value)
        {
            this._spSiteSubstitute.Shim.PortalNameGet = () => (string)value;
        }
    }
}

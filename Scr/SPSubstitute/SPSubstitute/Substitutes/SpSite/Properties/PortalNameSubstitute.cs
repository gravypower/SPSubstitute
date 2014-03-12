namespace SPSubstitute.Substitutes.SPSite.Properties
{
    public class PortalNameSubstitute : Map
    {
        private readonly SPSiteSubstitute _spSiteSubstitute;

        public string Value { get; set; }

        public PortalNameSubstitute(SPSiteSubstitute spSiteSubstitute)
        {
            _spSiteSubstitute = spSiteSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            _spSiteSubstitute.Actions.Add(site => DoMap(value));
            
        }

        public void DoMap(object value)
        {
            _spSiteSubstitute.Shim.PortalNameGet = () => (string)value;
        }
    }
}

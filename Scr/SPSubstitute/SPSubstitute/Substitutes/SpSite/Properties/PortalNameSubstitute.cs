namespace SPSubstitute.Substitutes.SpSite.Properties
{
    public class PortalNameSubstitute : Map
    {
        private readonly SpSiteSubstitute spSiteSubstitute;

        public string Value { get; set; }

        public PortalNameSubstitute(SpSiteSubstitute spSiteSubstitute)
        {
            this.spSiteSubstitute = spSiteSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            this.spSiteSubstitute.Actions.Add(site => DoMap(value));
            
        }

        public void DoMap(object value)
        {
            this.spSiteSubstitute.Shim.PortalNameGet = () => (string)value;
        }
    }
}

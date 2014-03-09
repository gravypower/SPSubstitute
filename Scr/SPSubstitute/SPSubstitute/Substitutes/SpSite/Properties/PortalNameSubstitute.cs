namespace SPSubstitute.Substitutes.SpSite.Properties
{
    public class PortalNameSubstitute : Map
    {
        private readonly SubstituteSpSite substituteSpSite;

        public string Value { get; set; }

        public PortalNameSubstitute(SubstituteSpSite substituteSpSite)
        {
            this.substituteSpSite = substituteSpSite;
        }

        public override void MapObjectValue(object value)
        {
            this.substituteSpSite.Actions.Add(site => DoMap(value));
            
        }

        public void DoMap(object value)
        {
            this.substituteSpSite.Shim.PortalNameGet = () => (string)value;
        }
    }
}

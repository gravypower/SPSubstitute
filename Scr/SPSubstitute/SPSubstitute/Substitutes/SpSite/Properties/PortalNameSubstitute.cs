using SPSubstitute.Substitutes.SPSite;

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

        public override void MapValue(object value)
        {
            this.substituteSpSite.Actions.Add(site => DoMap(value));
            
        }

        public override void DoMap(object value)
        {
            this.substituteSpSite.Shim.PortalNameGet = () => (string)value;
        }
    }
}

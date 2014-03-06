using SPSubstitute.Substitutes.SPSite;

namespace SPSubstitute.Substitutes.SpSite.Properties
{
    public class PortalName : Map
    {
        private readonly SubstituteSpSite _substituteSpSite;

        public string Value { get; set; }

        public PortalName(SubstituteSpSite substituteSpSite)
        {
            _substituteSpSite = substituteSpSite;
        }

        public override void MapValue(object value)
        {
            _substituteSpSite.Actions.Add(site => DoMap(value));
            
        }

        public override void DoMap(object value)
        {
            _substituteSpSite.Shim.PortalNameGet = () => (string)value;
        }
    }
}

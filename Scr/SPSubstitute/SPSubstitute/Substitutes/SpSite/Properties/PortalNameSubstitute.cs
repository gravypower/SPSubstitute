namespace SPSubstitute.Substitutes.SPSite.Properties
{
    public class PortalNameSubstitute
    {
        private readonly SPSiteSubstitute _spSiteSubstitute;

        public string Value { get; set; }

        public PortalNameSubstitute(SPSiteSubstitute spSiteSubstitute)
        {
            _spSiteSubstitute = spSiteSubstitute;
        }

        public void Returns(string portalName)
        {
            _spSiteSubstitute.Actions.Add(site => DoMap(portalName));
        }

        public void DoMap(string value)
        {
            _spSiteSubstitute.Shim.PortalNameGet = () => value;
        }
    }
}

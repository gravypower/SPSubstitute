namespace SPSubstitute.Substitutes.SPWeb.Properties
{
    using Shared.Webs;
    using Microsoft.SharePoint.Fakes;
    using Microsoft.SharePoint;

    public class WebsSubstitute : WebsBase<ShimSPWeb, SPWeb>
    {
        private readonly SPWebSubstitute _spWebSubstitute;

        public WebsSubstitute(SPWebSubstitute spWebSubstitute)
            : base(spWebSubstitute)
        {
            _spWebSubstitute = spWebSubstitute;
        }

        public SPWebSubstitute Add(string webUrl, string title, string description, uint lcid, string webTemplate,
            bool useUniquePermissions, bool bConvertIfThere)
        {
            _spWebSubstitute.WebsCollections[webUrl] = new SPWebSubstitute(Arg.Any()) {Shim = new ShimSPWeb()};
            return _spWebSubstitute.WebsCollections[webUrl];
        }

        public override void SetFakesDelegate(System.Func<ShimSPWebCollection> action)
        {
            _spWebSubstitute.Shim.WebsGet = () => action.Invoke();
        }
    }
}

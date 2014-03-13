using SPSubstitute.Substitutes.SPWeb;

namespace SPSubstitute.Substitutes.SPSite.Methods
{
    using Microsoft.SharePoint.Fakes;

    public class OpenWebSubstitute
    {
        private readonly SPSiteSubstitute _spSiteSubstitute;

        public OpenWebSubstitute(SPSiteSubstitute spSiteSubstitute)
        {
            _spSiteSubstitute = spSiteSubstitute;
        }

        public void Returns(SPWebSubstitute web)
        {
            _spSiteSubstitute.Shim = new ShimSPSite();

            _spSiteSubstitute.Actions.Add(
                site =>
                {
                    _spSiteSubstitute.Shim.OpenWeb = () => web.SpType;

                    foreach (var action in web.Actions)
                    {
                        action.Invoke(web.Shim);
                    }
                });
        }

    }
}

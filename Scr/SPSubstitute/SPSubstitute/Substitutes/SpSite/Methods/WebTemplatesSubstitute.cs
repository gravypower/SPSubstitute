namespace SPSubstitute.Substitutes.SPSite.Methods
{
    using System.Collections.Generic;

    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;
    using System.Linq;

    using SpWebTemplate;
    using SpWebTemplateCollection;

    public class WebTemplatesSubstitute
    {
        private readonly SPSiteSubstitute _spSiteSubstitute;

        private readonly uint _lcid;

        private Arg _args;

        public WebTemplatesSubstitute(SPSiteSubstitute spSiteSubstitute, uint lcid)
        {
            _lcid = lcid;
            _spSiteSubstitute = spSiteSubstitute;
        }

        public WebTemplatesSubstitute(SPSiteSubstitute spSiteSubstitute, Arg args)
        {
            _args = args;
            _spSiteSubstitute = spSiteSubstitute;
        }

        public void Returns(IList<SPWebTemplateSubstitute> templates)
        {
            _spSiteSubstitute.Shim = new ShimSPSite();

            _spSiteSubstitute.Actions.Add(
                site =>
                {
                    _spSiteSubstitute.Shim.GetWebTemplatesUInt32 = lcid =>
                    {
                        var shim = new ShimSPWebTemplateCollection();

                        var webTemplates = templates.Select(x => x.SpType);
                        shim.Bind(webTemplates);

                        return shim;
                    };
                });
        }

        public void Returns(SPWebTemplateCollectionSubstitute templates)
        {
            _spSiteSubstitute.WebTemplateCollections[_lcid] = templates;
            _spSiteSubstitute.Actions.Add(site => DoMap());
        }

        public void DoMap()
        {
            _spSiteSubstitute.Shim.GetWebTemplatesUInt32 = lcid => _spSiteSubstitute.WebTemplateCollections[lcid].SpType;
        }
    }
}

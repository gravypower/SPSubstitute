namespace SPSubstitute.Substitutes.SPSite.Methods
{
    using System.Collections.Generic;

    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;
    using System.Linq;

    using SpWebTemplate;
    using SpWebTemplateCollection;

    public class WebTemplatesSubstitute : Map
    {
        private readonly SPSiteSubstitute _spSiteSubstitute;

        private readonly uint lcid;

        private Arg args;

        public WebTemplatesSubstitute(SPSiteSubstitute _spSiteSubstitute, uint lcid)
        {
            this.lcid = lcid;
            this._spSiteSubstitute = _spSiteSubstitute;
        }

        public WebTemplatesSubstitute(SPSiteSubstitute _spSiteSubstitute, Arg args)
        {
            this.args = args;
            this._spSiteSubstitute = _spSiteSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            if (args == null)
            {
                _spSiteSubstitute.WebTemplateCollections[lcid] = new SPWebTemplateCollectionSubstitute((SPWebTemplateCollection)value);
                _spSiteSubstitute.Actions.Add(site => DoMap());
            }
            else
            {
                _spSiteSubstitute.Shim = new ShimSPSite();

                _spSiteSubstitute.Actions.Add(
                    site =>
                        {
                            _spSiteSubstitute.Shim.GetWebTemplatesUInt32 = lcid =>
                                {
                                    var shim = new ShimSPWebTemplateCollection();

                                    var webTemplates = ((List<SPWebTemplateSubstitute>)value).Select(x => x.SpType);
                                    shim.Bind(webTemplates);

                                    return shim;
                                };
                        });
            }
        }

        public void DoMap()
        {
            this._spSiteSubstitute.Shim.GetWebTemplatesUInt32 = lcid => _spSiteSubstitute.WebTemplateCollections[lcid].SpType;
        }
    }
}

namespace SPSubstitute.Substitutes.SpSite.Methods
{
    using System.Collections.Generic;

    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;
    using System.Linq;

    using SpWebTemplate;
    using SpWebTemplateCollection;

    public class WebTemplatesSubstitute : Map
    {
        private readonly SpSiteSubstitute spSiteSubstitute;

        private readonly uint lcid;

        private Arg args;

        public WebTemplatesSubstitute(SpSiteSubstitute spSiteSubstitute, uint lcid)
        {
            this.lcid = lcid;
            this.spSiteSubstitute = spSiteSubstitute;
        }

        public WebTemplatesSubstitute(SpSiteSubstitute spSiteSubstitute, Arg args)
        {
            this.args = args;
            this.spSiteSubstitute = spSiteSubstitute;
        }

        public override void MapObjectValue(object value)
        {
            if (args == null)
            {
                spSiteSubstitute.WebTemplateCollections[lcid] = new SpWebTemplateCollectionSubstitute((SPWebTemplateCollection)value);
                spSiteSubstitute.Actions.Add(site => DoMap());
            }
            else
            {
                spSiteSubstitute.Shim = new ShimSPSite();

                spSiteSubstitute.Actions.Add(
                    site =>
                        {
                            spSiteSubstitute.Shim.GetWebTemplatesUInt32 = lcid =>
                                {
                                    var shim = new ShimSPWebTemplateCollection();

                                    var webTemplates = ((List<SpWebTemplateSubstitute>)value).Select(x => x.SpType);
                                    shim.Bind(webTemplates);

                                    return shim;
                                };
                        });
            }
        }

        public void DoMap()
        {
            this.spSiteSubstitute.Shim.GetWebTemplatesUInt32 = lcid => spSiteSubstitute.WebTemplateCollections[lcid].SpType;
        }
    }
}

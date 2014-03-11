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
        private readonly SubstituteSpSite substituteSpSite;

        private readonly uint lcid;

        private Arg args;

        public WebTemplatesSubstitute(SubstituteSpSite substituteSpSite, uint lcid)
        {
            this.lcid = lcid;
            this.substituteSpSite = substituteSpSite;
        }

        public WebTemplatesSubstitute(SubstituteSpSite substituteSpSite, Arg args)
        {
            this.args = args;
            this.substituteSpSite = substituteSpSite;
        }

        public override void MapObjectValue(object value)
        {
            if (args == null)
            {
                substituteSpSite.WebTemplateCollections[lcid] = new SubstituteSpWebTemplateCollection((SPWebTemplateCollection)value);
                substituteSpSite.Actions.Add(site => DoMap());
            }
            else
            {
                substituteSpSite.Shim = new ShimSPSite();

                substituteSpSite.Actions.Add(
                    site =>
                        {
                            substituteSpSite.Shim.GetWebTemplatesUInt32 = lcid =>
                                {
                                    var shim = new ShimSPWebTemplateCollection();

                                    var webTemplates = ((List<SubstituteSpWebTemplate>)value).Select(x => x.SpType);
                                    shim.Bind(webTemplates);

                                    return shim;
                                };
                        });
            }
        }

        public void DoMap()
        {
            this.substituteSpSite.Shim.GetWebTemplatesUInt32 = lcid => substituteSpSite.WebTemplateCollections[lcid].SpType;
        }
    }
}

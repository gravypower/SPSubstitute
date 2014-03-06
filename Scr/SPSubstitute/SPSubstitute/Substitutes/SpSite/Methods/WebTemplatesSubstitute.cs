using Microsoft.SharePoint;
using SPSubstitute.Substitutes.SPSite;

namespace SPSubstitute.Substitutes.SpSite.Methods
{
    public class WebTemplatesSubstitute : Map
    {
        private readonly SubstituteSpSite substituteSpSite;

        public WebTemplatesSubstitute(SubstituteSpSite substituteSpSite)
        {
            this.substituteSpSite = substituteSpSite;
        }

        public override void DoMap(object value)
        {
            this.substituteSpSite.Shim.GetWebTemplatesUInt32 = u => (SPWebTemplateCollection)value;
        }

        public override void MapValue(object value)
        {
            this.substituteSpSite.Actions.Add(site => DoMap(value));
        }
    }
}

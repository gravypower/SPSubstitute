using Microsoft.SharePoint;
using SPSubstitute.Substitutes.SPSite;

namespace SPSubstitute.Substitutes.SpSite.Methods
{
    public class WebTemplates : Map
    {
        private readonly SubstituteSpSite _substituteSpSite;

        public WebTemplates(SubstituteSpSite substituteSpSite)
        {
            _substituteSpSite = substituteSpSite;
        }

        public override void DoMap(object value)
        {
            _substituteSpSite.Shim.GetWebTemplatesUInt32 = u => (SPWebTemplateCollection)value;
        }

        public override void MapValue(object value)
        {
            _substituteSpSite.Actions.Add(site => DoMap(value));
        }
    }
}

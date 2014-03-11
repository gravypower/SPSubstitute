using System.Collections.Generic;

namespace SPSubstitute.Substitutes.SpWeb.Collections
{
    public class WebsCollections
    {
        private readonly Dictionary<string, SubstituteSpWeb> stringSpWeb;
        public SubstituteSpWeb this[string name]
        {
            get
            {
                return stringSpWeb[name];
            }
            set { stringSpWeb[name] = value; }
        }

        public IEnumerable<SubstituteSpWeb> SpWebs
        {
            get { return stringSpWeb.Values; }
        }

        public WebsCollections()
        {
            stringSpWeb = new Dictionary<string, SubstituteSpWeb>();
        }
    }
}

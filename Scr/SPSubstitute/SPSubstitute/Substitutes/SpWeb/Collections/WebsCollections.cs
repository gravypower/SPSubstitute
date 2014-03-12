using System.Collections.Generic;
using System.Linq;

namespace SPSubstitute.Substitutes.SpWeb.Collections
{
    public class WebsCollections
    {
        private readonly Dictionary<string, SpWebSubstitute> stringSpWeb;
        public SpWebSubstitute this[string name]
        {
            get
            {
                return stringSpWeb[name];
            }
            set { stringSpWeb[name] = value; }
        }

        public IList<SpWebSubstitute> SpWebs
        {
            get { return stringSpWeb.Values.ToList(); }
        }

        public WebsCollections()
        {
            stringSpWeb = new Dictionary<string, SpWebSubstitute>();
        }
    }
}

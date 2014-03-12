using System.Collections.Generic;
using System.Linq;

namespace SPSubstitute.Substitutes.SPWeb.Collections
{
    public class WebsCollections
    {
        private readonly Dictionary<string, WebSubstitute> stringSpWeb;
        public WebSubstitute this[string name]
        {
            get
            {
                return stringSpWeb[name];
            }
            set { stringSpWeb[name] = value; }
        }

        public IList<WebSubstitute> SpWebs
        {
            get { return stringSpWeb.Values.ToList(); }
        }

        public WebsCollections()
        {
            stringSpWeb = new Dictionary<string, WebSubstitute>();
        }
    }
}

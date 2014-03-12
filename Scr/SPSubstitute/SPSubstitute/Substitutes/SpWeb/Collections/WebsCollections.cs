using System.Collections.Generic;
using System.Linq;

namespace SPSubstitute.Substitutes.SPWeb.Collections
{
    public class WebsCollections
    {
        private readonly Dictionary<string, SPWebSubstitute> _stringSpWeb;
        public SPWebSubstitute this[string name]
        {
            get
            {
                return _stringSpWeb[name];
            }
            set { _stringSpWeb[name] = value; }
        }

        public IList<SPWebSubstitute> SpWebs
        {
            get { return _stringSpWeb.Values.ToList(); }
        }

        public WebsCollections()
        {
            _stringSpWeb = new Dictionary<string, SPWebSubstitute>();
        }
    }
}

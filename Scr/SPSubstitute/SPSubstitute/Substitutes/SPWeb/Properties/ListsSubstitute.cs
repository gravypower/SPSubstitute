using System.Collections.Generic;
using SPSubstitute.Substitutes.SPList;

namespace SPSubstitute.Substitutes.SPWeb.Properties
{
    public class ListsSubstitute
    {
        private SPWebSubstitute _substitute;

        public ListsSubstitute(SPWebSubstitute substitute)
        {
            _substitute = substitute;
        }

        public void Returns(IList<SPListSubstitute> lists)
        {
            
        }
    }
}

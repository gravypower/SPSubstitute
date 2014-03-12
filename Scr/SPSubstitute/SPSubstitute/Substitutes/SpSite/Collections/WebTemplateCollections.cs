using SPSubstitute.Substitutes.SpWebTemplateCollection;

namespace SPSubstitute.Substitutes.SPSite.Collections
{
    using System.Collections.Generic;

    public class WebTemplateCollections
    {
        public WebTemplateCollections()
        {
            this.webTemplateCollections = new Dictionary<uint, SPWebTemplateCollectionSubstitute>();
        }

        private readonly Dictionary<uint, SPWebTemplateCollectionSubstitute> webTemplateCollections;
        public SPWebTemplateCollectionSubstitute this[uint guid]
        {
            get
            {
                return this.webTemplateCollections[guid];
            }
            set { this.webTemplateCollections[guid] = value; }
        }
    }
}

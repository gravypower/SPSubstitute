namespace SPSubstitute.Substitutes.SpSite.Collections
{
    using System.Collections.Generic;

    using SPSubstitute.Substitutes.SpWebTemplateCollection;

    public class WebTemplateCollections
    {
        public WebTemplateCollections()
        {
            this.webTemplateCollections = new Dictionary<uint, SubstituteSpWebTemplateCollection>();
        }

        private readonly Dictionary<uint, SubstituteSpWebTemplateCollection> webTemplateCollections;
        public SubstituteSpWebTemplateCollection this[uint guid]
        {
            get
            {
                return this.webTemplateCollections[guid];
            }
            set { this.webTemplateCollections[guid] = value; }
        }
    }
}

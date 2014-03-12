namespace SPSubstitute.Substitutes.SpSite.Collections
{
    using System.Collections.Generic;

    using SPSubstitute.Substitutes.SpWebTemplateCollection;

    public class WebTemplateCollections
    {
        public WebTemplateCollections()
        {
            this.webTemplateCollections = new Dictionary<uint, SpWebTemplateCollectionSubstitute>();
        }

        private readonly Dictionary<uint, SpWebTemplateCollectionSubstitute> webTemplateCollections;
        public SpWebTemplateCollectionSubstitute this[uint guid]
        {
            get
            {
                return this.webTemplateCollections[guid];
            }
            set { this.webTemplateCollections[guid] = value; }
        }
    }
}

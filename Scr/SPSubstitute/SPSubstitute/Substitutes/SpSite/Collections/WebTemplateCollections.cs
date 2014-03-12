namespace SPSubstitute.Substitutes.SPSite.Collections
{
    using System.Collections.Generic;
    using SpWebTemplateCollection;

    public class WebTemplateCollections
    {
        public WebTemplateCollections()
        {
            _webTemplateCollections = new Dictionary<uint, SPWebTemplateCollectionSubstitute>();
        }

        private readonly Dictionary<uint, SPWebTemplateCollectionSubstitute> _webTemplateCollections;
        public SPWebTemplateCollectionSubstitute this[uint guid]
        {
            get
            {
                return _webTemplateCollections[guid];
            }
            set { _webTemplateCollections[guid] = value; }
        }
    }
}

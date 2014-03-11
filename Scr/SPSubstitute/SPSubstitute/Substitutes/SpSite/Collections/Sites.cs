namespace SPSubstitute.Substitutes.SpSite.Collections
{
    using System;
    using System.Collections.Generic;

    using SpSite;

    public class Sites
    {
        public Sites ()
        {
            this.guildSites = new Dictionary<Guid, SubstituteSpSite>();
            this.requestUrlSites = new Dictionary<string, SubstituteSpSite>();
        }
        private readonly Dictionary<Guid, SubstituteSpSite> guildSites;
        public SubstituteSpSite this[Guid guid]
        {
            get
            {
                return this.guildSites[guid];
            }
            set { this.guildSites[guid] = value; }
        }

        private readonly Dictionary<string, SubstituteSpSite> requestUrlSites;
        public SubstituteSpSite this[string requestUrl]
        {
            get
            {
                return this.requestUrlSites[requestUrl];
            }
            set { this.requestUrlSites[requestUrl] = value; }
        }

        private SubstituteSpSite site;
        public SubstituteSpSite this[Arg requestUrl]
        {
            get
            {
                return site;
            }
            set { site = value; }
        }
    }
}

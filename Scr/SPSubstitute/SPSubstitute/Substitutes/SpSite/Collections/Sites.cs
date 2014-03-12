namespace SPSubstitute.Substitutes.SpSite.Collections
{
    using System;
    using System.Collections.Generic;

    using SpSite;

    public class Sites
    {
        public Sites ()
        {
            this.guildSites = new Dictionary<Guid, SpSiteSubstitute>();
            this.requestUrlSites = new Dictionary<string, SpSiteSubstitute>();
        }

        private readonly Dictionary<Guid, SpSiteSubstitute> guildSites;
        public SpSiteSubstitute this[Guid guid]
        {
            get
            {
                return this.guildSites[guid];
            }
            set { this.guildSites[guid] = value; }
        }

        private readonly Dictionary<string, SpSiteSubstitute> requestUrlSites;
        public SpSiteSubstitute this[string requestUrl]
        {
            get
            {
                return this.requestUrlSites[requestUrl];
            }
            set { this.requestUrlSites[requestUrl] = value; }
        }

        private SpSiteSubstitute site;
        public SpSiteSubstitute this[Arg requestUrl]
        {
            get
            {
                return site;
            }
            set { site = value; }
        }
    }
}

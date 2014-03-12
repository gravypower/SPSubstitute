namespace SPSubstitute.Substitutes.SPSite.Collections
{
    using System;
    using System.Collections.Generic;

    using SPSite;

    public class Sites
    {
        public Sites ()
        {
            this.guildSites = new Dictionary<Guid, SPSiteSubstitute>();
            this.requestUrlSites = new Dictionary<string, SPSiteSubstitute>();
        }

        private readonly Dictionary<Guid, SPSiteSubstitute> guildSites;
        public SPSiteSubstitute this[Guid guid]
        {
            get
            {
                return this.guildSites[guid];
            }
            set { this.guildSites[guid] = value; }
        }

        private readonly Dictionary<string, SPSiteSubstitute> requestUrlSites;
        public SPSiteSubstitute this[string requestUrl]
        {
            get
            {
                return this.requestUrlSites[requestUrl];
            }
            set { this.requestUrlSites[requestUrl] = value; }
        }

        private SPSiteSubstitute _spSite;
        public SPSiteSubstitute this[Arg requestUrl]
        {
            get
            {
                return _spSite;
            }
            set { _spSite = value; }
        }
    }
}

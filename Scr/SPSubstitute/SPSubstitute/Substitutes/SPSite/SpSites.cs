namespace SPSubstitute.Substitutes.SpSite
{
    using System;
    using System.Collections.Generic;

    public class SpSites : ISpSites
    {
        public SpSites ()
        {
            this.guildSites = new Dictionary<Guid, SubstituteSpSite>();
            this.requestUrlSites = new Dictionary<string, SubstituteSpSite>();
        }

        private readonly Dictionary<Guid, SubstituteSpSite> guildSites;
        public SubstituteSpSite this[Guid guid]
        {
            get
            {
                if (!this.guildSites.ContainsKey(guid))
                    this.guildSites.Add(guid, new SubstituteSpSite());

                return this.guildSites[guid];
            }
        }

        private readonly Dictionary<string, SubstituteSpSite> requestUrlSites;
        public SubstituteSpSite this[string requestUrl]
        {
            get
            {
                if (!this.requestUrlSites.ContainsKey(requestUrl))
                    this.requestUrlSites.Add(requestUrl, new SubstituteSpSite());

                return this.requestUrlSites[requestUrl];
            }
        }
    }
}

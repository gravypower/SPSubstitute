﻿using SPSubstitute.Substitutes.SPSite;

namespace SPSubstitute.Substitutes.SpSite
{
    using System;
    using System.Collections.Generic;

    public class SpSites
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
    }
}

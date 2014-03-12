namespace SPSubstitute.Substitutes.SPSite.Collections
{
    using System;
    using System.Collections.Generic;

    using SPSite;

    public class Sites
    {
        public Sites ()
        {
            _guildSites = new Dictionary<Guid, SPSiteSubstitute>();
            _requestUrlSites = new Dictionary<string, SPSiteSubstitute>();
        }

        private readonly Dictionary<Guid, SPSiteSubstitute> _guildSites;
        public SPSiteSubstitute this[Guid guid]
        {
            get
            {
                return _guildSites[guid];
            }
            set { _guildSites[guid] = value; }
        }

        private readonly Dictionary<string, SPSiteSubstitute> _requestUrlSites;
        public SPSiteSubstitute this[string requestUrl]
        {
            get
            {
                return _requestUrlSites[requestUrl];
            }
            set { _requestUrlSites[requestUrl] = value; }
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

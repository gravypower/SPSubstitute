using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute
{
    public interface ISpSites
    {
        SpSubstituteSite this[Guid guid] { get; }
        SpSubstituteSite this[string requestUrl] { get; }
    }

    public class SpSites : ISpSites
    {
        public SpSites ()
        {
            _guildSites = new Dictionary<Guid, SpSubstituteSite>();
            _requestUrlSites = new Dictionary<string, SpSubstituteSite>();
        }

        private readonly Dictionary<Guid, SpSubstituteSite> _guildSites;
        public SpSubstituteSite this[Guid guid]
        {
            get
            {
                if (!_guildSites.ContainsKey(guid))
                    _guildSites.Add(guid, new SpSubstituteSite(new ShimSPSite()));

                return _guildSites[guid];
            }
        }

        private readonly Dictionary<string, SpSubstituteSite> _requestUrlSites;
        public SpSubstituteSite this[string requestUrl]
        {
            get
            {
                if (!_requestUrlSites.ContainsKey(requestUrl))
                    _requestUrlSites.Add(requestUrl, new SpSubstituteSite(new ShimSPSite()));

                return _requestUrlSites[requestUrl];
            }
        }
    }
}

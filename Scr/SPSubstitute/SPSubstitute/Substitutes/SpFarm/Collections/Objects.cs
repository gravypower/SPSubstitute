namespace SPSubstitute.Substitutes.SPFarm.Collections
{
    using System;
    using System.Collections.Generic;
    using SPPersistedObject;

    public class Objects
    {
        public Objects()
        {
            _guildObjects = new Dictionary<Guid, SPPersistedObjectSubstitute>();
        }

        private readonly Dictionary<Guid, SPPersistedObjectSubstitute> _guildObjects;
        public SPPersistedObjectSubstitute this[Guid guid]
        {
            get
            {
                return _guildObjects[guid];
            }
            set { _guildObjects[guid] = value; }
        }
    }
}

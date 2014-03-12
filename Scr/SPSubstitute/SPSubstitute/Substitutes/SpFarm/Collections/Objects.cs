using SPSubstitute.Substitutes.SPPersistedObject;

namespace SPSubstitute.Substitutes.SPFarm.Collections
{
    using System;
    using System.Collections.Generic;


    public class Objects
    {
        public Objects()
        {
            this.guildObjects = new Dictionary<Guid, SPPersistedObjectSubstitute>();
        }

        private readonly Dictionary<Guid, SPPersistedObjectSubstitute> guildObjects;
        public SPPersistedObjectSubstitute this[Guid guid]
        {
            get
            {
                return this.guildObjects[guid];
            }
            set { this.guildObjects[guid] = value; }
        }
    }
}

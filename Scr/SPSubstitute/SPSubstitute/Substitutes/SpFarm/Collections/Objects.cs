namespace SPSubstitute.Substitutes.SpFarm.Collections
{
    using System;
    using System.Collections.Generic;

    using SPSubstitute.Substitutes.SpPersistedObject;

    public class Objects
    {
        public Objects()
        {
            this.guildObjects = new Dictionary<Guid, SpPersistedObjectSubstitute>();
        }

        private readonly Dictionary<Guid, SpPersistedObjectSubstitute> guildObjects;
        public SpPersistedObjectSubstitute this[Guid guid]
        {
            get
            {
                return this.guildObjects[guid];
            }
            set { this.guildObjects[guid] = value; }
        }
    }
}

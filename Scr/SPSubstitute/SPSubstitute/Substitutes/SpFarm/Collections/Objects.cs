namespace SPSubstitute.Substitutes.SpFarm.Collections
{
    using System;
    using System.Collections.Generic;

    using SPSubstitute.Substitutes.SpPersistedObject;

    public class Objects
    {
        public Objects()
        {
            this.guildObjects = new Dictionary<Guid, SubstituteSpPersistedObject>();
        }

        private readonly Dictionary<Guid, SubstituteSpPersistedObject> guildObjects;
        public SubstituteSpPersistedObject this[Guid guid]
        {
            get
            {
                return this.guildObjects[guid];
            }
            set { this.guildObjects[guid] = value; }
        }
    }
}

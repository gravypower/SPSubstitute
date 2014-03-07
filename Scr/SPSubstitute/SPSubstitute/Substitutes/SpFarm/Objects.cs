using System;
using System.Collections.Generic;
using SPSubstitute.Substitutes.SpFarm.Methods;

namespace SPSubstitute.Substitutes.SpFarm
{
    public class Objects
    {
        public Objects()
        {
            this.guildObjects = new Dictionary<Guid, GetObjectSubstitute>();
        }

        private readonly Dictionary<Guid, GetObjectSubstitute> guildObjects;
        public GetObjectSubstitute this[Guid guid]
        {
            get
            {
                return this.guildObjects[guid];
            }
            set { this.guildObjects[guid] = value; }
        }
    }
}

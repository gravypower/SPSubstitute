﻿using Microsoft.SharePoint.Administration.Fakes;

namespace SPSubstitute.Substitutes.SpFarm.Tasks
{
    public class LocalGet : Task<SubstituteSpFarm>
    {
        public LocalGet(SubstituteSpFarm substitute) : base(substitute)
        {
        }

        public override void Run()
        {
            ShimSPFarm.LocalGet = () =>
                {
                    this.SpSubstitute.Invoke();
                    return this.SpSubstitute.SpType;
                };
        }
    }
}

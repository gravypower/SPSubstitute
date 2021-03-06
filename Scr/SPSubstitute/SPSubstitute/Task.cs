﻿namespace SPSubstitute
{
    using Substitutes;
    
    public abstract class Task<TSubstitute>
        where TSubstitute : ISubstitute
    {
        protected TSubstitute FarmSpSiteSubstitute;

        protected Arg Args;

        protected Task(TSubstitute farmSpSiteSubstitute, Arg args)
        {
            FarmSpSiteSubstitute = farmSpSiteSubstitute;
            Args = args;
        }

        protected Task(TSubstitute farmSpSiteSubstitute)
        {
            FarmSpSiteSubstitute = farmSpSiteSubstitute;
        }

        public abstract void Run();
    }
}

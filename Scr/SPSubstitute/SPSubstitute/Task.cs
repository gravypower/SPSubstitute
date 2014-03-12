using SPSubstitute.Substitutes;

namespace SPSubstitute
{
    public abstract class Task<TSpSubstitute>
        where TSpSubstitute : SpSubstitute
    {
        protected TSpSubstitute SpSpFarmSpSiteSubstitute;

        protected Arg Args;

        protected Task(TSpSubstitute spFarmSpSiteSubstitute, Arg args)
        {
            SpSpFarmSpSiteSubstitute = spFarmSpSiteSubstitute;
            Args = args;
        }

        protected Task(TSpSubstitute spFarmSpSiteSubstitute)
        {
            SpSpFarmSpSiteSubstitute = spFarmSpSiteSubstitute;
        }

        public abstract void Run();
    }
}

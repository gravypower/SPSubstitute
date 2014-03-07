using SPSubstitute.Substitutes;

namespace SPSubstitute
{
    public abstract class Task<TSpSubstitute>
        where TSpSubstitute : SpSubstitute
    {
        protected TSpSubstitute SpSubstitute;

        protected Task(TSpSubstitute substitute)
        {
            SpSubstitute = substitute;
        }

        public abstract void Run();
    }
}

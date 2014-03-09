using SPSubstitute.Substitutes;

namespace SPSubstitute
{
    public abstract class Task<TSpSubstitute>
        where TSpSubstitute : SpSubstitute
    {
        protected TSpSubstitute SpSubstitute;

        protected Arg Args;

        protected Task(TSpSubstitute substitute, Arg args)
        {
            SpSubstitute = substitute;
            Args = args;
        }

        protected Task(TSpSubstitute substitute)
        {
            SpSubstitute = substitute;
        }

        public abstract void Run();
    }
}

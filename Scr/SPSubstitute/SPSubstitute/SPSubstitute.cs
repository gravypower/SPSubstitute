namespace SPSubstitute
{
    public static class SpSubstitute
    {
        public static T For<T>(params object[] constructorArguments)
            where T : class, new()
        {
            return new T();
        }
    }
}

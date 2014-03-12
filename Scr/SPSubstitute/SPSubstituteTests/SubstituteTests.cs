namespace SPSubstituteTests
{
    using SPSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public abstract class SubstituteTests
    {
        protected SubstituteContext SubstituteContext;

        [SetUp]
        public virtual void SetUp()
        {
            SubstituteContext = new SubstituteContext();
        }

        [TearDown]
        public virtual void TearDown()
        {
            SubstituteContext.Dispose();
            SubstituteContext = null;
        }
    }
}

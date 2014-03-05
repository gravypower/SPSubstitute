namespace SPSubstituteTests
{
    using NUnit.Framework;

    using SPSubstitute;

    [TestFixture]
    public abstract class SubstituteTests
    {
        protected SpSubstituteContext Sut;

        [SetUp]
        public virtual void SetUp()
        {
            Sut = SpSubstituteContext.NewContext();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Sut.Dispose();
            Sut = null;
        }
    }
}

namespace SPSubstituteTests
{
    using System;

    using Microsoft.QualityTools.Testing.Fakes;

    using NUnit.Framework;

    [TestFixture]
    public abstract class SubstituteTests
    {
        protected IDisposable ShimContext;

        [SetUp]
        public virtual void SetUp()
        {
            ShimContext = ShimsContext.Create();
        }

        [TearDown]
        public virtual void TearDown()
        {
            ShimContext.Dispose();
            ShimContext = null;
        }
    }
}

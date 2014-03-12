using NUnit.Framework;
using SPSubstitute;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SubstituteContextTests:SubstituteTests
    {
        [Test]
        public void IsCurrentContextCorrect()
        {
            Assert.That(SubstituteContext.CurrentContext, Is.SameAs(SubstituteContext));
        }
    }
}

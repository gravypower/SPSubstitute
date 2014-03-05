namespace SPSubstituteTests
{
    using NUnit.Framework;

    using SPSubstitute;
    using SPSubstitute.Substitutes.SpSite;
    using SPSubstitute.Substitutes.SpSite.Methods;

    [TestFixture]
    public class SpSubstituteTests : SubstituteTests
    {
        [Test]
        public void t()
        {
            var x = new SubstituteSpSite();

            x.WebTemplates(1033).Returns(new WebTemplates(new SubstituteSpSite()));
        }

    }
}

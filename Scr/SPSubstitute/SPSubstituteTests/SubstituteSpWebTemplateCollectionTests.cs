namespace SPSubstituteTests
{
    using NUnit.Framework;

    [TestFixture]
    public class SubstituteSpWebTemplateCollectionTests : SubstituteTests
    {

        [Test]
        public void SomeTest()
        {
            uint lcid = 1033;
            var templates = Sut.MockSpWebTemplateCollection(lcid);
        }
    }
}

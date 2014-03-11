using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute.Substitutes.SpWeb;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SubstituteSpWebTests : SubstituteTests
    {
        [Test]
        public void SomeTest()
        {
            //Arrange
            var substituteWeb = new SubstituteSpWeb();
            var requestUrl = "http://SomeURL";

            //Act
            var newSubstituteWeb = substituteWeb.Webs.Add("SomeURL", "Title", "Description", 1033, "Web Template", false, false);

            //Assert
            using (var site = new SPSite(requestUrl))
            {
                using (var web = site.OpenWeb())
                {
                    Assert.That(web.Webs[0], Is.Not.Null);
                }
            }
        }
    }
}

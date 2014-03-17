using System.Collections.Generic;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute.Substitutes.SPSite;
using SPSubstitute.Substitutes.SPWeb;

namespace SPSubstituteTests.SPWebTests
{
    [TestFixture]
    public abstract class SPWebSubstituteTests : SubstituteTests
    {
        protected abstract SPSite GetSite();

        protected SPSiteSubstitute SPSiteSubstitute;

        [Test]
        public void CanSubstituteWebAndAddWebNoArgumentFromSite()
        {
            //Arrange
            var spWebSubstitute = new SPWebSubstitute();

            //Act
            var newSubstituteWeb = spWebSubstitute.Webs.Add("SomeOther", "Title", "Description", 1033, "Web Template", false, false);

            //Assert
            using (var site = GetSite())
            {
                using (var web = site.OpenWeb())
                {
                    Assert.That(web, Is.SameAs(spWebSubstitute.SpType));
                    Assert.That(web.Webs, Is.Not.Null);
                    Assert.That(web.Webs[0], Is.Not.Null);
                    Assert.That(web.Webs[0], Is.SameAs(newSubstituteWeb.SpType));
                }
            }
        }

        [Test]
        public void CanSetReturnOnWebsToAListOfSPWebSubstitute()
        {
            //Arrange
            var spWebSubstitute = new SPWebSubstitute();

            var webSubstitute = SPWebSubstitute.CreateSPWebSubstitute();

            var webs = new List<SPWebSubstitute>
            {
                webSubstitute
            };

            //Act
            spWebSubstitute.Webs.Returns(webs);

            //Assert
            using (var site = GetSite())
            {
                using (var web = site.OpenWeb())
                {
                    Assert.That(web, Is.SameAs(spWebSubstitute.SpType));
                    Assert.That(web.Webs, Is.Not.Null);
                    Assert.That(web.Webs[0], Is.Not.Null);
                    Assert.That(web.Webs, Contains.Item(webSubstitute.SpType));
                }
            }
        }
    }
}

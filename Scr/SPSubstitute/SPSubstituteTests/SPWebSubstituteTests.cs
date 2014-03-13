using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute;
using SPSubstitute.Substitutes.SPWeb;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SPWebSubstituteTests : SubstituteTests
    {
        [Test]
        public void CanSubstituteWebAndAddWebNoArgumentFromSiteFromString()
        {
            //Arrange
            var spWebSubstitute = new SPWebSubstitute();
            var requestUrl = "http://SomeURL";

            //Act
            var newSubstituteWeb = spWebSubstitute.Webs.Add("SomeOther", "Title", "Description", 1033, "Web Template", false, false);

            //Assert
            using (var site = new SPSite(requestUrl))
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
        public void CanSubstituteWebAndAddWebNoArgumentFromSiteFromGuid()
        {
            //Arrange
            var spWebSubstitute = new SPWebSubstitute();
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");

            //Act
            var newSubstituteWeb = spWebSubstitute.Webs.Add("SomeOther", "Title", "Description", 1033, "Web Template", false, false);

            //Assert
            using (var site = new SPSite(guild))
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
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");

            var webSubstitute = new SPWebSubstitute(Arg.Any());
            var webs = new List<SPWebSubstitute>
            {
                webSubstitute
            };

            //Act
            spWebSubstitute.Webs.Returns(webs);

            //Assert
            using (var site = new SPSite(guild))
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

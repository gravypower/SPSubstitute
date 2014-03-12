using System;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute.Substitutes.SpWeb;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SubstituteSpWebTests : SubstituteTests
    {
        [Test]
        public void CanSubstituteWebAndAddWebNoArgumentFromSiteFromString()
        {
            //Arrange
            var substituteWeb = new SpWebSubstitute();
            var requestUrl = "http://SomeURL";

            //Act
            var newSubstituteWeb = substituteWeb.Webs.Add("SomeOther", "Title", "Description", 1033, "Web Template", false, false);

            //Assert
            using (var site = new SPSite(requestUrl))
            {
                using (var web = site.OpenWeb())
                {
                    Assert.That(web.Webs[0], Is.Not.Null);
                    Assert.That(web.Webs[0], Is.SameAs(newSubstituteWeb.SpType));
                }
            }
        }

        [Test]
        public void CanSubstituteWebAndAddWebNoArgumentFromSiteFromGuid()
        {
            //Arrange
            var substituteWeb = new SpWebSubstitute();
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");

            //Act
            var newSubstituteWeb = substituteWeb.Webs.Add("SomeOther", "Title", "Description", 1033, "Web Template", false, false);

            //Assert
            using (var site = new SPSite(guild))
            {
                using (var web = site.OpenWeb())
                {
                    Assert.That(web.Webs[0], Is.Not.Null);
                    Assert.That(web.Webs[0], Is.SameAs(newSubstituteWeb.SpType));
                }
            }
        }
    }
}

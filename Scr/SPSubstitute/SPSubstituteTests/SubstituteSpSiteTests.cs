using SPSubstitute;
using SPSubstitute.Substitutes.SpSite;
using SPSubstitute.Substitutes.SpWebTemplateCollection;

namespace SPSubstituteTests
{
    using System;
    using NUnit.Framework;
    using Microsoft.SharePoint;

    [TestFixture]
    public class SubstituteSpSiteTests : SubstituteTests
    {
        [Test]
        public void CanSubstituteSiteWithGuid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");

            var substituteSpSite = new SubstituteSpSite(guild);

            //Act
            SPSite spSite;
            using (var site = new SPSite(guild))
            {
                spSite = site;
            }

            //Assert
            Assert.That(substituteSpSite.SpType, Is.SameAs(spSite));
        }

        [Test]
        public void CanSubstituteSiteRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";

            var substituteSpSite = new SubstituteSpSite(requestUrl);

            //Act
            SPSite spSite;
            using (var site = new SPSite(requestUrl))
            {
                spSite = site;
            }

            //Assert
            Assert.That(substituteSpSite.SpType, Is.SameAs(spSite));
        }


        [Test]
        public void CanSubstitutePortalNameWithMockedSiteFromRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";
            var portalName = "SomeTitle";

            var substituteSpSite = new SubstituteSpSite(requestUrl);
            
            //Act
            substituteSpSite.PortalName.Returns(portalName);

            //Assert
            using (var site = new SPSite(requestUrl))
            {
                Assert.That(site.PortalName, Is.SameAs(portalName));
            }
            
        }

        [Test]
        public void CanReturnPortalNameWithMockedSiteFromGuid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var portalName = "SomeTitle";
            var substituteSpSite = new SubstituteSpSite(guild);

            //Act
            substituteSpSite.PortalName.Returns(portalName);

            //Assert
            using (var site = new SPSite(guild))
            {
                Assert.That(site.PortalName, Is.SameAs(portalName));
            }
        }

        [Test]
        public void CanReturnSpWebTemplateCollectionFromLcid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var substituteSpSite = new SubstituteSpSite(guild);

            var templateCollection = new SubstituteSpWebTemplateCollection();
            uint lcid = 1033;

            //Act
            substituteSpSite.WebTemplates(lcid).Returns(templateCollection);

            //Assert
            using (var site = new SPSite(guild))
            {
                Assert.That(site.GetWebTemplates(lcid), Is.SameAs(templateCollection.SpType));
            }
        }

        [Test]
        public void CanReturnSpWebTemplateCollectionFromTwoDifferentLcid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var substituteSpSite = new SubstituteSpSite(guild);

            var templateCollectionOne = new SubstituteSpWebTemplateCollection();
            uint lcidOne = 1033;

            var templateCollectionTwo = new SubstituteSpWebTemplateCollection();
            uint lcidTwo = 1034;

            //Act
            substituteSpSite.WebTemplates(lcidOne).Returns(templateCollectionOne);
            substituteSpSite.WebTemplates(lcidTwo).Returns(templateCollectionTwo);

            //Assert
            using (var site = new SPSite(guild))
            {
                Assert.That(templateCollectionOne.SpType, Is.SameAs(site.GetWebTemplates(lcidOne)));
                Assert.That(templateCollectionTwo.SpType, Is.SameAs(site.GetWebTemplates(lcidTwo)));
            }
        }
    }
}

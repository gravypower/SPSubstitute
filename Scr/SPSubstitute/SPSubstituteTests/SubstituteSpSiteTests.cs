using SPSubstitute;
using SPSubstitute.Substitutes.SPSite;
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
            Assert.AreSame(spSite, substituteSpSite.SpType);
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
            Assert.AreSame(spSite, substituteSpSite.SpType);
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
                Assert.AreSame(portalName, site.PortalName);
            }
            
        }

        [Test]
        public void CanSubstitutePortalNameWithMockedSiteFromGuid()
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
                Assert.AreEqual(portalName, site.PortalName);
            }
        }

        [Test]
        public void CanSubstituteSpWebTemplateCollection()
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
                Assert.AreSame(templateCollection.SpType, site.GetWebTemplates(lcid));
            }
        }
    }
}

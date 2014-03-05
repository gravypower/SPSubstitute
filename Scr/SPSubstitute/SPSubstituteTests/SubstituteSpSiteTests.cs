namespace SPSubstituteTests
{
    using System;
    using NUnit.Framework;
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Fakes;

    [TestFixture]
    public class SubstituteSpSiteTests : SubstituteTests
    {
        [SetUp]
        public virtual void FixtureSetUp()
        {
            Sut.SetUpForSpSite();
        }

        [Test]
        public void CanMockSiteWithGuid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");

            var mockedSite = Sut.MockSpSite(guild);

            //Act

            SPSite spSite;
            using (var site = new SPSite(guild))
            {
                spSite = site;
            }

            //Assert
            Assert.AreSame(spSite, mockedSite.SpSite);
        }

        [Test]
        public void CanMockSiteRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";
            var mockedSite = Sut.MockSpSite(requestUrl);

            //Act
            SPSite spSite;
            using (var site = new SPSite(requestUrl))
            {
                spSite = site;
            }

            //Assert
            Assert.AreSame(spSite, mockedSite.SpSite);
        }


        [Test]
        public void CanSubstitutePortalNameWithMockedSiteFromRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";
            var portalName = "SomeTitle";
            var mockedSite = Sut.MockSpSite(requestUrl);
            
            //Act
            mockedSite.PortalName.DoMap(portalName);

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
            var mockedSite = Sut.MockSpSite(guild);

            //Act
            mockedSite.PortalName.DoMap(portalName);

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
            var mockedSite = Sut.MockSpSite(guild);
            var templateCollection = new ShimSPWebTemplateCollection();
            uint lcid = 1033;

            //Act
            mockedSite.WebTemplates(lcid).DoMap(templateCollection);


            //Assert
            using (var site = new SPSite(guild))
            {
                Assert.AreSame((SPWebTemplateCollection)templateCollection, site.GetWebTemplates(lcid));
            }
        }
    }
}

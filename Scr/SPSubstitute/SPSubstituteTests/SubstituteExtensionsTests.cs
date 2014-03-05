using System;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SubstituteExtensionsTests
    {
        protected SPSubstituteContext Sut;

        [SetUp]
        public virtual void SetUp()
        {
            Sut = SPSubstituteContext.NewContext();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Sut.Dispose();
            Sut = null;
        }

        [Test]
        public void CanMockSiteWithGuid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");

            var mockedSite = Sut.MockSite(guild);

            //Act

            SPSite spSite;
            using (var site = new SPSite(guild))
            {
                spSite = site;
            }

            //Assert
            Assert.AreSame(mockedSite.SpSite, spSite);
        }

        [Test]
        public void CanMockSiteRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";
            var mockedSite = Sut.MockSite(requestUrl);

            //Act
            SPSite spSite;
            using (var site = new SPSite(requestUrl))
            {
                spSite = site;
            }

            //Assert
            Assert.AreSame(mockedSite.SpSite, spSite);
        }

        [Test]
        public void CanSubstitutePortalNameWithMockedSiteFromRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";
            var portalName = "SomeTitle";
            var mockedSite = Sut.MockSite(requestUrl);
            
            //Act
            mockedSite.PortalName.Returns(portalName);

            //Assert
            using (var site = new SPSite(requestUrl))
            {
                Assert.AreSame(site.PortalName, portalName);
            }
            
        }

        [Test]
        public void CanSubstitutePortalNameWithMockedSiteFromGuid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var portalName = "SomeTitle";
            var mockedSite = Sut.MockSite(guild);

            //Act
            mockedSite.PortalName.Returns(portalName);

            //Assert
            using (var site = new SPSite(guild))
            {
                Assert.AreEqual(site.PortalName, portalName);
            }
        }
    }
}

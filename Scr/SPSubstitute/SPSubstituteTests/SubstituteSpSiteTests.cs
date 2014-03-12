﻿using SPSubstitute;
using SPSubstitute.Substitutes.SPSite;
using SPSubstitute.Substitutes.SPWeb;
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

            var spSiteSubstitute = new SPSiteSubstitute(guild);

            //Act
            SPSite spSite;
            using (var site = new SPSite(guild))
            {
                spSite = site;
            }

            //Assert
            Assert.That(spSiteSubstitute.SpType, Is.SameAs(spSite));
        }

        [Test]
        public void CanSubstituteSiteRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";

            var spSiteSubstitute = new SPSiteSubstitute(requestUrl);

            //Act
            SPSite spSite;
            using (var site = new SPSite(requestUrl))
            {
                spSite = site;
            }

            //Assert
            Assert.That(spSiteSubstitute.SpType, Is.SameAs(spSite));
        }


        [Test]
        public void CanSubstitutePortalNameWithMockedSiteFromRequestUrl()
        {
            //Arrange
            var requestUrl = "http://SomeURL";
            var portalName = "SomeTitle";

            var spSiteSubstitute = new SPSiteSubstitute(requestUrl);
            
            //Act
            spSiteSubstitute.PortalName.Returns(portalName);

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
            var spSiteSubstitute = new SPSiteSubstitute(guild);

            //Act
            spSiteSubstitute.PortalName.Returns(portalName);

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
            var spSiteSubstitute = new SPSiteSubstitute(guild);

            var templateCollection = new SPWebTemplateCollectionSubstitute();
            uint lcid = 1033;

            //Act
            spSiteSubstitute.WebTemplates(lcid).Returns(templateCollection);

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
            var spSiteSubstitute = new SPSiteSubstitute(guild);

            var templateCollectionOne = new SPWebTemplateCollectionSubstitute();
            uint lcidOne = 1033;

            var templateCollectionTwo = new SPWebTemplateCollectionSubstitute();
            uint lcidTwo = 1034;

            //Act
            spSiteSubstitute.WebTemplates(lcidOne).Returns(templateCollectionOne);
            spSiteSubstitute.WebTemplates(lcidTwo).Returns(templateCollectionTwo);

            //Assert
            using (var site = new SPSite(guild))
            {
                Assert.That(site.GetWebTemplates(lcidOne), Is.SameAs(templateCollectionOne.SpType));
                Assert.That(site.GetWebTemplates(lcidTwo), Is.SameAs(templateCollectionTwo.SpType));
            }
        }

        [Test]
        public void CanOpenWebWithNoArgumentFromSiteFromGuid()
        {
            //Arrange
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var spSiteSubstitute = new SPSiteSubstitute(guild);

            var web = new SPWebSubstitute();

            //Act
            spSiteSubstitute.OpenWeb().Returns(web);
             //Assert
            using (var site = new SPSite(guild))
            {
                Assert.That(site.OpenWeb(), Is.SameAs(web.SpType));
            }
        }

        [Test]
        public void CanOpenWebWithNoArgumentFromSiteFromString()
        {
            //Arrange
            var requestUrl = "http://SomeURL";
            var spSiteSubstitute = new SPSiteSubstitute(requestUrl);

            var web = new SPWebSubstitute();

            //Act
            spSiteSubstitute.OpenWeb().Returns(web);
            //Assert
            using (var site = new SPSite(requestUrl))
            {
                Assert.That(site.OpenWeb(), Is.SameAs(web.SpType));
            }
        }
    }
}

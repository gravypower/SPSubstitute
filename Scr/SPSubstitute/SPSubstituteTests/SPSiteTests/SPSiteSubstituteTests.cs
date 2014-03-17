using System.Collections.Generic;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute;
using SPSubstitute.Substitutes.SPSite;
using SPSubstitute.Substitutes.SPWeb;
using SPSubstitute.Substitutes.SpWebTemplateCollection;

namespace SPSubstituteTests.SPSiteTests
{
    [TestFixture]
    public abstract class SPSiteSubstituteTests : SubstituteTests
    {
        protected SPSiteSubstitute Sut;

        protected abstract SPSite GetSite();

        [Test]
        public void CanSubstituteSite()
        {
            //Act
            SPSite spSite;

            using (var site = GetSite())
            {
                spSite = site;
            }

            //Assert
            Assert.That(Sut.SpType, Is.SameAs(spSite));
        }

        [Test]
        public void CanSubstitutePortalNameWithMockedSite()
        {
            //Arrange
            var portalName = "SomeTitle";
            
            //Act
            Sut.PortalName.Returns(portalName);

            //Assert
            using (var site = GetSite())
            {
                Assert.That(site.PortalName, Is.SameAs(portalName));
            }
        }

        [Test]
        public void CanReturnSpWebTemplateCollectionFromLcid()
        {
            //Arrange
            var templateCollection = new SPWebTemplateCollectionSubstitute();
            uint lcid = 1033;

            //Act
            Sut.WebTemplates(lcid).Returns(templateCollection);

            //Assert
            using (var site = GetSite())
            {
                Assert.That(site.GetWebTemplates(lcid), Is.SameAs(templateCollection.SpType));
            }
        }

        [Test]
        public void CanReturnSpWebTemplateCollectionFromTwoDifferentLcid()
        {
            //Arrange
           var templateCollectionOne = new SPWebTemplateCollectionSubstitute();
            uint lcidOne = 1033;

            var templateCollectionTwo = new SPWebTemplateCollectionSubstitute();
            uint lcidTwo = 1034;

            //Act
            Sut.WebTemplates(lcidOne).Returns(templateCollectionOne);
            Sut.WebTemplates(lcidTwo).Returns(templateCollectionTwo);

            //Assert
            using (var site = GetSite())
            {
                Assert.That(site.GetWebTemplates(lcidOne), Is.SameAs(templateCollectionOne.SpType));
                Assert.That(site.GetWebTemplates(lcidTwo), Is.SameAs(templateCollectionTwo.SpType));
            }
        }

        [Test]
        public void CanOpenWebWithNoArgument()
        {
            //Arrange
            var web = new SPWebSubstitute();

            //Act
            Sut.OpenWeb().Returns(web);
            
            //Assert
            using (var site = GetSite())
            {
                Assert.That(site.OpenWeb(), Is.SameAs(web.SpType));
            }
        }

        [Test]
        public void CanGetAllWebsFromASite()
        {
            //Arrange
            var webSubstitute = new SPWebSubstitute(Arg.Any());
            var webs = new List<SPWebSubstitute>
            {
                webSubstitute
            };

            //Act
            Sut.AllWebs.Returns(webs);

            //Assert
            using (var site = GetSite())
            {
                Assert.That(site.AllWebs, Is.Not.Null);
                Assert.That(site.AllWebs[0], Is.Not.Null);
                Assert.That(site.AllWebs, Contains.Item(webSubstitute.SpType));
            }
        }
    }
}

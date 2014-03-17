using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute.Substitutes.SpWebTemplate;
using SPSubstitute.Substitutes.SpWebTemplateCollection;

namespace SPSubstituteTests.SPWebTemplateCollectionTests
{
    [TestFixture]
    public class SPWebTemplateCollectionSubstituteTests : SubstituteTests
    {
        [Test]
        public void SubstituteTemplateCollectionAlsoSubstitutesSiteWithString()
        {
            //Arrange
            var spWebTemplateCollectionSubstitute = new SPWebTemplateCollectionSubstitute();

            var webTemplates = new List<SPWebTemplateSubstitute>();

            //Act
            spWebTemplateCollectionSubstitute.Returns(webTemplates);

            //Assert
            using (var site = new SPSite("http://SomeURL"))
            {
                Assert.That(site, Is.Not.Null);
            }
        }

        [Test]
        public void SubstituteTemplateCollectionAlsoSubstitutesSiteWithGuid()
        {
            //Arrange
            var spWebTemplateCollectionSubstitute = new SPWebTemplateCollectionSubstitute();

            var webTemplates = new List<SPWebTemplateSubstitute>();

            //Act
            spWebTemplateCollectionSubstitute.Returns(webTemplates);

            //Assert
            using (var site = new SPSite(new Guid()))
            {
                Assert.That(site, Is.Not.Null);
            }
        }

        [Test]
        public void CanGetWebTemplateFromSubstituteTemplateCollection()
        {
            //Arrange
            var spWebTemplateCollectionSubstitute = new SPWebTemplateCollectionSubstitute();

            var webTemplate = new SPWebTemplateSubstitute();

            var template = new List<SPWebTemplateSubstitute>
                               {
                                   webTemplate
                               };

            //Act
            spWebTemplateCollectionSubstitute.Returns(template);

            //Assert
            using (var site = new SPSite("http://SomeURL"))
            {
                Assert.That(site.GetWebTemplates(1033), Contains.Item(webTemplate.SpType));
            }
        }
    }
}

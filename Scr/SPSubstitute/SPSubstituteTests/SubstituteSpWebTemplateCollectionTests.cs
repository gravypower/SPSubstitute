namespace SPSubstituteTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.SharePoint;

    using NUnit.Framework;

    using SPSubstitute;
    using SPSubstitute.Substitutes.SpWebTemplate;
    using SPSubstitute.Substitutes.SpWebTemplateCollection;

    [TestFixture]
    public class SubstituteSpWebTemplateCollectionTests : SubstituteTests
    {
        [Test]
        public void SubstituteTemplateCollectionAlsoSubstitutesSiteWithString()
        {
            //Arrange
            var templateCollection = new SubstituteSpWebTemplateCollection();

            var WebTemplates = new List<SubstituteSpWebTemplate>();

            //Act
            templateCollection.Returns(WebTemplates);

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
            var templateCollection = new SubstituteSpWebTemplateCollection();

            var WebTemplates = new List<SubstituteSpWebTemplate>();

            //Act
            templateCollection.Returns(WebTemplates);

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
            var templateCollection = new SubstituteSpWebTemplateCollection();

            var webTemplate = new SubstituteSpWebTemplate();

            var template = new List<SubstituteSpWebTemplate>
                               {
                                   webTemplate
                               };

            //Act
            templateCollection.Returns(template);

            //Assert
            using (var site = new SPSite("http://SomeURL"))
            {
                Assert.That(site.GetWebTemplates(1033), Contains.Item(webTemplate.SpType));
            }
        }
    }
}

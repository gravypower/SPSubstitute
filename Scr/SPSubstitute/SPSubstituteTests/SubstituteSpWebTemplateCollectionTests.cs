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
            var templateCollection = new SpWebTemplateCollectionSubstitute();

            var WebTemplates = new List<SpWebTemplateSubstitute>();

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
            var templateCollection = new SpWebTemplateCollectionSubstitute();

            var WebTemplates = new List<SpWebTemplateSubstitute>();

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
            var templateCollection = new SpWebTemplateCollectionSubstitute();

            var webTemplate = new SpWebTemplateSubstitute();

            var template = new List<SpWebTemplateSubstitute>
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

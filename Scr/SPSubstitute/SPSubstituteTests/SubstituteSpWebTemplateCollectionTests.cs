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
            var templateCollection = new SPWebTemplateCollectionSubstitute();

            var WebTemplates = new List<SPWebTemplateSubstitute>();

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
            var templateCollection = new SPWebTemplateCollectionSubstitute();

            var WebTemplates = new List<SPWebTemplateSubstitute>();

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
            var templateCollection = new SPWebTemplateCollectionSubstitute();

            var webTemplate = new SPWebTemplateSubstitute();

            var template = new List<SPWebTemplateSubstitute>
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

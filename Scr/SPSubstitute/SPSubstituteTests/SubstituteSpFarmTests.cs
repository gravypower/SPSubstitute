using System;

using Microsoft.SharePoint.Administration;
using NUnit.Framework;
using SPSubstitute;
using SPSubstitute.Substitutes.SpFarm;
using SPSubstitute.Substitutes.SpWebApplication;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SubstituteSpFarmTests : SubstituteTests
    {
        [Test]
        public void CanSubstituteSpFarmLocal()
        {
            //Act
            var substituteSpFarm = new SpFarmSubstitute();

            //Assert
            Assert.That(SPFarm.Local, Is.Not.Null);
            Assert.That(SPFarm.Local, Is.SameAs(substituteSpFarm.SpType));
        }

        [Test]
        public void CanReturnWebApplicationFromGetObject()
        {
            //Assign
            var substituteSpFarm = new SpFarmSubstitute();
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var webApplication = new SpWebApplicationSubstitute();

            //Act
            substituteSpFarm.GetObject(guild).Returns(webApplication);


            //Assert
            Assert.That(SPFarm.Local, Is.Not.Null);
            Assert.That(SPFarm.Local.GetObject(guild), Is.Not.Null);
            Assert.That(SPFarm.Local.GetObject(guild), Is.SameAs(webApplication.SpType));
        }

        [Test]
        public void CanReturnTwoWebApplicationFromGetObject()
        {
            //Assign
            var substituteSpFarm = new SpFarmSubstitute();
            
            var guildOne = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var webApplicationOne = new SpWebApplicationSubstitute();

            var guildTwo = new Guid("c1c353d1-ad6c-459c-bd78-419df29aa8a6");
            var webApplicationTwo = new SpWebApplicationSubstitute();

            //Act
            substituteSpFarm.GetObject(guildOne).Returns(webApplicationOne);
            substituteSpFarm.GetObject(guildTwo).Returns(webApplicationTwo);


            //Assert
            Assert.That(SPFarm.Local, Is.Not.Null);

            Assert.That(SPFarm.Local.GetObject(guildOne), Is.Not.Null);
            Assert.That(SPFarm.Local.GetObject(guildOne), Is.SameAs(webApplicationOne.SpType));

            Assert.That(SPFarm.Local.GetObject(guildTwo), Is.Not.Null);
            Assert.That(SPFarm.Local.GetObject(guildTwo), Is.SameAs(webApplicationTwo.SpType));
        }
    }
}

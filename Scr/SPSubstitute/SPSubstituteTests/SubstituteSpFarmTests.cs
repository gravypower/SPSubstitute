using System;

using Microsoft.SharePoint.Administration;
using NUnit.Framework;
using SPSubstitute;
using SPSubstitute.Substitutes.SPFarm;
using SPSubstitute.Substitutes.SPWebApplication;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SubstituteSpFarmTests : SubstituteTests
    {
        [Test]
        public void CanSubstituteSpFarmLocal()
        {
            //Act
            var substituteSpFarm = new SPFarmSubstitute();

            //Assert
            Assert.That(SPFarm.Local, Is.Not.Null);
            Assert.That(SPFarm.Local, Is.SameAs(substituteSpFarm.SpType));
        }

        [Test]
        public void CanReturnWebApplicationFromGetObject()
        {
            //Assign
            var substituteSpFarm = new SPFarmSubstitute();
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var webApplication = new SPWebApplicationSubstitute();

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
            var substituteSpFarm = new SPFarmSubstitute();
            
            var guildOne = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var webApplicationOne = new SPWebApplicationSubstitute();

            var guildTwo = new Guid("c1c353d1-ad6c-459c-bd78-419df29aa8a6");
            var webApplicationTwo = new SPWebApplicationSubstitute();

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

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
            var substituteSpFarm = new SubstituteSpFarm();

            //Assert
            Assert.IsNotNull(SPFarm.Local);
            Assert.AreSame(substituteSpFarm.SpType, SPFarm.Local);
        }

        [Test]
        public void CanReturnWebApplicationFromGetObject()
        {
            //Assign
            var substituteSpFarm = new SubstituteSpFarm();
            var guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var webApplication = new SubstituteSpWebApplication();

            //Act
            substituteSpFarm.GetObject(guild).Returns(webApplication);


            //Assert
            Assert.IsNotNull(SPFarm.Local);
            Assert.IsNotNull(SPFarm.Local.GetObject(guild));
            Assert.AreSame(webApplication.SpType, SPFarm.Local.GetObject(guild));
        }

        [Test]
        public void CanReturnTwoWebApplicationFromGetObject()
        {
            //Assign
            var substituteSpFarm = new SubstituteSpFarm();
            
            var guildOne = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");
            var webApplicationOne = new SubstituteSpWebApplication();

            var guildTwo = new Guid("c1c353d1-ad6c-459c-bd78-419df29aa8a6");
            var webApplicationTwo = new SubstituteSpWebApplication();

            //Act
            substituteSpFarm.GetObject(guildOne).Returns(webApplicationOne);
            substituteSpFarm.GetObject(guildTwo).Returns(webApplicationTwo);


            //Assert
            Assert.IsNotNull(SPFarm.Local);

            Assert.IsNotNull(SPFarm.Local.GetObject(guildOne));
            Assert.AreSame(webApplicationOne.SpType, SPFarm.Local.GetObject(guildOne));

            Assert.IsNotNull(SPFarm.Local.GetObject(guildTwo));
            Assert.AreSame(webApplicationTwo.SpType, SPFarm.Local.GetObject(guildTwo));
        }
    }
}

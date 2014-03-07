using System;
using System.Runtime.InteropServices;
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
        public void SomeTest()
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
    }
}

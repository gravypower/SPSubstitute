using Microsoft.SharePoint;
using NUnit.Framework;

namespace SPSubstituteTests
{
    [TestFixture]
    public class SPSecurityTests : SubstituteTests
    {
        [Test]
        public void CanRunCodeWithElevatedPrivileges()
        {
            //Act
            SPSecurity.RunWithElevatedPrivileges(() => {var t = true;});
        }

        [Test]
        public void CanSpyOnRunCodeWithElevatedPrivilegesHasCodeRun()
        {
            //Act
            SPSecurity.RunWithElevatedPrivileges(() => { 
                //Some Code
            });

            //Assert
            Assert.That(SubstituteContext.HasCodeRunWithElevatedPrivileges, Is.True);
        }
    }
}

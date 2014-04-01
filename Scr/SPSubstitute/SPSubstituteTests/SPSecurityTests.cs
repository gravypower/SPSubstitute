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
            SPSecurity.RunWithElevatedPrivileges(() => { });

            //Assert
            Assert.That(SubstituteContext.HasCodeRunWithElevatedPrivileges, Is.True);
        }

        [Test]
        public void CanSpyOnRunCodeWithElevatedPrivilegesHasCodeCodeToRunElevated()
        {
            //Assign
            SPSecurity.CodeToRunElevated t = () => { };
            
            //Act
            SPSecurity.RunWithElevatedPrivileges(t);

            //Assert
            Assert.That(SubstituteContext.HasCodeRunWithElevatedPrivilegesDelegate, Is.EqualTo(t));
        }
    }
}

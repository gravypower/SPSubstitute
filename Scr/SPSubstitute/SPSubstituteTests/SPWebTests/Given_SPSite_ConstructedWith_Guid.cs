using System;
using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute.Substitutes.SPSite;

namespace SPSubstituteTests.SPWebTests
{
    [TestFixture]
    public class Given_SPSite_ConstructedWith_Guid : SPWebSubstituteTests
    {
        private Guid _guild;

        [SetUp]
        public void ConstructedWithGuidSetUp()
        {
            _guild = new Guid("08f1cfef-9898-436d-a6d4-1aaecb22d5e0");

            SPSiteSubstitute = new SPSiteSubstitute(_guild);
        }

        protected override SPSite GetSite()
        {
            return new SPSite(_guild);
        }
    }
}

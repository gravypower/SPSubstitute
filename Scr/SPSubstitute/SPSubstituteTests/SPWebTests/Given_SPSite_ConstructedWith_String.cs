using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute.Substitutes.SPSite;

namespace SPSubstituteTests.SPWebTests
{
    [TestFixture]
    public class Given_SPSite_ConstructedWith_String : SPWebSubstituteTests
    {
        private string _requestUrl;

        [SetUp]
        public void ConstructedWithGuidSetUp()
        {
            _requestUrl = "http://SomeURL";

            SPSiteSubstitute = new SPSiteSubstitute(_requestUrl);
        }

        protected override SPSite GetSite()
        {
            return new SPSite(_requestUrl);
        }
    }
}

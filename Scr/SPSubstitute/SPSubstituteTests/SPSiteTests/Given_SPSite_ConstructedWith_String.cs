﻿using Microsoft.SharePoint;
using NUnit.Framework;
using SPSubstitute.Substitutes.SPSite;

namespace SPSubstituteTests.SPSiteTests
{
    [TestFixture]
    public class Given_SPSite_ConstructedWith_String : SPSiteSubstituteTests
    {
        private string _requestUrl;

        [SetUp]
        public void ConstructedWithGuidSetUp()
        {
            _requestUrl = "http://SomeURL";

            Sut = new SPSiteSubstitute(_requestUrl);
        }

        protected override SPSite GetSite()
        {
            return new SPSite(_requestUrl);
        }
    }
}

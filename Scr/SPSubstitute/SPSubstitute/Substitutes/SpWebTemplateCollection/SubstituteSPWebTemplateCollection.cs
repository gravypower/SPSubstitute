﻿using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpWebTemplateCollection
{
    using SPSubstitute.Substitutes.SpSite;

    public class SubstituteSpWebTemplateCollection : SpSubstitute<ShimSPWebTemplateCollection, SPWebTemplateCollection>, IMap
    {
        public SubstituteSpWebTemplateCollection(SPWebTemplateCollection webTemplateCollection)
        {
            Shim = new ShimSPWebTemplateCollection(webTemplateCollection);
        }

        public SubstituteSpWebTemplateCollection()
        {
            Shim = new ShimSPWebTemplateCollection();
        }

        public void MapObjectValue(object value)
        {
            var site = new SubstituteSpSite(Arg.Any());
            site.WebTemplates(Arg.Any()).Returns(value);
        }
    }
}

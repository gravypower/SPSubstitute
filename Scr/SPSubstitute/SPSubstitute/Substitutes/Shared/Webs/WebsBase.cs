namespace SPSubstitute.Substitutes.Shared.Webs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.QualityTools.Testing.Fakes.Shims;
    using Microsoft.SharePoint.Fakes;
    using SPWeb;
    using SPWeb.Collections;

    public abstract class WebsBase<TShim, TSpType>
        where TSpType : class
        where TShim : ShimBase<TSpType>, new()
    {
        protected Substitute<TShim, TSpType> Substitute;

        protected WebsBase(Substitute<TShim, TSpType> substitute)
        {
            Substitute = substitute;
        }

        public abstract void SetFakesDelegate(Func<ShimSPWebCollection> action);

        public void Returns(IList<SPWebSubstitute> webs)
        {
            Substitute.Actions.Add(delegate
            {
                SetFakesDelegate( () =>
                {
                    var shim = new ShimSPWebCollection();

                    var webTemplates = webs.Select(x => x.SpType);
                    shim.Bind(webTemplates);

                    shim.ItemGetInt32 = i => webs[i].SpType;

                    return shim;
                });
            });
        }

        public void Returns(WebsCollections websCollections)
        {
            Substitute.Actions.Add(delegate
            {
                SetFakesDelegate(() =>
                {
                    var shim = new ShimSPWebCollection();

                    var webs = websCollections.SpWebs.Select(x => x.SpType);

                    shim.ItemGetInt32 = i => websCollections.SpWebs[i].SpType;

                    shim.Bind(webs);

                    return shim;
                });
            });
        }
    }
}

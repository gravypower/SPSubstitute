namespace SPSubstitute.Substitutes.SpSite
{
    using System;

    public interface ISpSites
    {
        SubstituteSpSite this[Guid guid] { get; }
        SubstituteSpSite this[string requestUrl] { get; }
    }
}
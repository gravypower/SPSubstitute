using System;
using Microsoft.QualityTools.Testing.Fakes;

namespace SPSubstitute
{
    public partial class SpSubstituteContext : IDisposable
    {
        protected IDisposable ShimContext;

        protected SpSubstituteContext()
        {
            ShimContext = ShimsContext.Create();
        }       

        public void Dispose()
        {
            ShimContext.Dispose();
        }

        public static SpSubstituteContext NewContext()
        {
            return new SpSubstituteContext();
        } 
    }
}

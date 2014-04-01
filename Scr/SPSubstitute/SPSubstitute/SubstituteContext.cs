using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;

namespace SPSubstitute
{
    public class SubstituteContext: IDisposable
    {
        protected IDisposable ShimContext;
        
        public SubstituteContext()
        {
            ShimContext = ShimsContext.Create();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = elevated =>
            {
                HasCodeRunWithElevatedPrivileges = true;
                HasCodeRunWithElevatedPrivilegesDelegate = elevated;
                elevated.Invoke();
            };

            CurrentContext = this;
        }

        public bool HasCodeRunWithElevatedPrivileges { get; private set; }
        public Delegate HasCodeRunWithElevatedPrivilegesDelegate { get; private set; }

        public static SubstituteContext CurrentContext { get; private set; }

        public void Dispose()
        {
            ShimContext.Dispose();
            ShimContext = null;
        }
    }
}

using Microsoft.SharePoint.Fakes;

namespace SPSubstitute.Substitutes.SpSecurity
{
    class Play
    {
        public Play()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated =
                elevated => elevated.Invoke();
        }
    }
}

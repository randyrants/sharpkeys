using System;
using System.Security.Principal;

namespace SharpKeys
{
    class Utilities
    {
        private static readonly Lazy<bool> s_isAdmin = new Lazy<bool>(() =>
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }, true);

        public static bool IsAdmin => s_isAdmin.Value;
    }
}

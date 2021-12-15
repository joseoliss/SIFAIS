using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SIFAIS
{
    public static class IdentityCache
    {
        public static string GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserId");
            return (claim != null) ? claim.Value : identity.Name;
        }

        public static string GetUserRolId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserRole");
            return (claim != null) ? claim.Value : identity.Name;
        }

        public static string GetUserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserName");
            return (claim != null) ? claim.Value : identity.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace WebbApp.Extensions
{
    public static class Extensions
    {
        public static string GetUserID(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserID");

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
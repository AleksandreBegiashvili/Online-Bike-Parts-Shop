using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabidBike.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if(httpContext.User == null)
            {
                return string.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "Id").Value;
        }

        public static bool IsAdmin(this HttpContext httpContext)
        {
            if(httpContext.User == null)
            {
                return false;
            }

            if(httpContext.User.IsInRole("Admin"))
            {
                return true;
            }

            return false;
        }
    }
}

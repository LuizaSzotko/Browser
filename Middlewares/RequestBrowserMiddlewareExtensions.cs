using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Browser.Middlewares
{
    public static class RequestBrowserMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestBrowser(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestBrowserMiddleware>();
        }
    }
}

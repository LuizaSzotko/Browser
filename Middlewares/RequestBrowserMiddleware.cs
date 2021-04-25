using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace Browser.Middlewares
{
    public class RequestBrowserMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestBrowserMiddleware (RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            string UA = context.Request.Headers["User-Agent"];
            string browser = "";
            string message = "";
            var uaParser = Parser.GetDefault();

            ClientInfo c = uaParser.Parse(UA);
            browser = c.UA.Family + " " + c.UA.Major + "." + c.UA.Minor;
           
            if (browser.Contains("Edge") || browser.Contains("IE"))
            {
                message = "Niestety, Twoja przegladarka nie jest obslugiwana.";
                await context.Response.WriteAsync(message);
            }

            await _next(context);
        }
    }
}

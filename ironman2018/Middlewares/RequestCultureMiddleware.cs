using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ironman2018.Middlewares
{
    public class RequestCultureMiddleware
    {
        private static readonly string[] EnabledCultures = new[] { "zh-tw", "en-us", "de-de" };

        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            
            var match = Regex.Match(path, $"^/({string.Join('|', EnabledCultures)})/CultureMiddleware");
            var defaultCulture = "zh-tw";
            if (match.Success)
            {
                defaultCulture = match.Groups[1].Value;

                context.Request.Path = new PathString("/CultureMiddleware/Index");
            }

            var culture = new CultureInfo(defaultCulture);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}

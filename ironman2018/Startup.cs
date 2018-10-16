using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ironman2018.Models.DependecyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ironman2018
{
    public class Startup
    {
        private static readonly string[] EnabledCultures = new[] { "zh-tw", "en-us", "de-de" };

        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                var path = context.Request.Path;

                var match = Regex.Match(path, $"/({string.Join('|', EnabledCultures)})");
                var defaultCulture = "zh-tw";
                if (match.Success)
                {
                    defaultCulture = match.Groups[1].Value;
                }

                var culture = new CultureInfo(defaultCulture);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

                // Call the next delegate/middleware in the pipeline
                return next();
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ironman2018
{
    public class Program
    {
        private static Dictionary<string, string> _inMemoryConfig = new Dictionary<string, string>
        {
            {"profile:name", "Rex"},
            {"creations:blogs:0:title", ".NET Core 介紹"},
            {"creations:blogs:1:title", "常用 dotnet 命令介紹"},
            {"creations:projects:0:name", "ironman2018"}
        };

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        // 原本是這樣
        //        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //            WebHost.CreateDefaultBuilder(args)
        //                .UseStartup<Startup>();

        // 改成這樣來讓應用程式找到對應環境的 Startup 類別
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var startupAssemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

            // ASP.NET Core 2.0 or earlier
            //            var configuration = new ConfigurationBuilder()
            //                .SetBasePath(Directory.GetCurrentDirectory())
            //                .AddInMemoryCollection(_inMemoryConfig)
            //                .AddJsonFile("appsettings.json")
            //                .AddCommandLine(args)
            //                .Build();
            //
            //            return WebHost.CreateDefaultBuilder(args)
            //                .UseConfiguration(configuration)
            //                .UseStartup(startupAssemblyName);

            return WebHost.CreateDefaultBuilder(args)
                // ASP.NET Core 2.1 or later
                .ConfigureAppConfiguration((hostContext, configBuilder) =>
                {
                    configBuilder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddInMemoryCollection(_inMemoryConfig)
                        .AddJsonFile("appsettings.json")
                        .AddCommandLine(args);
                })
                .UseStartup(startupAssemblyName);
        }
    }
}

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

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup(startupAssemblyName);
        }
    }
}

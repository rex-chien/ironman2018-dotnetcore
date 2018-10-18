using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ironman2018.Controllers
{
    public class StaticFilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Banner2()
        {
            var file = Path.Combine(
                Directory.GetCurrentDirectory(),
                "FileResults",
                "banner2.svg");

            return PhysicalFile(file, "image/svg+xml");
        }
    }
}
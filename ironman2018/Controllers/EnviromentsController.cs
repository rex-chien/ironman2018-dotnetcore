using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ironman2018.Models.Environments;
using Microsoft.AspNetCore.Mvc;

namespace ironman2018.Controllers
{
    public class EnviromentsController : Controller
    {
        private readonly IEnvironmentsService _environmentsService;

        public EnviromentsController(IEnvironmentsService environmentsService)
        {
            _environmentsService = environmentsService;
        }

        public IActionResult Index()
        {
            ViewBag.EnvironmentName = _environmentsService.GetEnvironmentName();

            return View();
        }

        public IActionResult StartupClassConvention()
        {
            return View();
        }

        public IActionResult StartupConfigureMethodConvention()
        {
            return View();
        }
    }
}
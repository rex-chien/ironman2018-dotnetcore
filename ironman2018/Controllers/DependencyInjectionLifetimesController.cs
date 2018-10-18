using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ironman2018.Models.DependecyInjection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ironman2018.Controllers
{
    public class DependencyInjectionLifetimesController : Controller
    {
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationSingletonInstance _singletonInstanceOperation;
        private readonly OperationService _operationService;

        public DependencyInjectionLifetimesController(IOperationTransient transientOperation, IOperationScoped scopedOperation, IOperationSingleton singletonOperation, IOperationSingletonInstance singletonInstanceOperation, OperationService operationService)
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;
            _operationService = operationService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Transient = _transientOperation;
            ViewBag.Scoped = _scopedOperation;
            ViewBag.Singleton = _singletonOperation;
            ViewBag.SingletonInstance = _singletonInstanceOperation;
            ViewBag.Service = _operationService;

            return View();
        }
    }
}

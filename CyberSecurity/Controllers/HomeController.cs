using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CyberSecurity.Models;
using CyberSecurity.Services;

namespace CyberSecurity.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBLLService _objIBLLService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBLLService bllservice)
        {
            _logger = logger;
            _objIBLLService = bllservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

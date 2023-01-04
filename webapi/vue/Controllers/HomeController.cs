using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using vue.Models;

namespace vue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult source()
        {
            return View();
        }

        public IActionResult memberLogin()
        {
            return View();
        }
        public IActionResult platform()
        {
            return View();
        }

        public IActionResult jobList()
        {
            return View();
        }


        public IActionResult courseManage()
        {
            return View();
        }

        public IActionResult jobSingle()
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
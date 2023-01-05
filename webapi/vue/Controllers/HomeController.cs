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

        // 資源
        public IActionResult source()
        {
            return View();
        }

        
        //會員中心
        public IActionResult memberLogin()
        {
            return View();
        }

        public IActionResult memberSignup()
        {
            return View();
        }

        //論壇
        public IActionResult platform()
        {
            return View();
        }

        //找工作
        public IActionResult jobList()
        {
            return View();
        }
        public IActionResult jobSingle()
        {
            return View();
        }

        //課程
        public IActionResult courseManage()
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
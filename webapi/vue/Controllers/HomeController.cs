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
            ViewBag.mark = "首頁";
            return View();
        }

        // 資源
        public IActionResult source()
        {
            return View();
        }

        public IActionResult sourcePage()
        {
            return View();
        }

        public IActionResult psychologicalTest()
        {
            return View();
        }

        public IActionResult testResult()
        {
            return View();
        }

        public IActionResult aboutUs()
        {
            return View();
        }

        public IActionResult sourceIndex()
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

        public IActionResult memberCenter()
        {
            return View();
        }

        public IActionResult memberApply()
        {
            return View();
        }

        public IActionResult memberFocus()
        {
            return View();
        }

        public IActionResult memberVacancies()
        {
            return View();
        }

        public IActionResult memberBlacklist()
        {
            return View();
        }

        public IActionResult memberDetail()
        {
            return View();
        }

        //企業端
        public IActionResult enterpriseIndex()
        {
            return View();
        }

        //論壇
        public IActionResult platform()
        {
            return View();
        }

        public IActionResult platformPost()
        {
            return View();
        }

        public IActionResult platformArticle()
        {
            return View();
        }

        //找工作
        public IActionResult jobList()
        {
            ViewBag.mark = "找工作";
            return View();
        }
        public IActionResult jobSingle()
        {
            return View();
        }

        //課程
        public IActionResult courseShop()
        {
            return View();
        }

        public IActionResult courseManage()
        {
            return View();
        }

        public IActionResult courseDetail()
        {
            return View();
        }
        public IActionResult payPage()
        {
            return View();
        }

        //履歷
        public IActionResult CV()
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
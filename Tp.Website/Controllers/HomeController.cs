using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp.Website.Models;

namespace Tp.Website.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }

        public virtual IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public virtual IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public virtual IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public virtual IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VehicleEfficiencyAcd.Presentation.Models;

namespace VehicleEfficiencyAcd.Presentation.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewData["ActiveController"] = "Home";
            ViewData["ActiveAction"] = "Index";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

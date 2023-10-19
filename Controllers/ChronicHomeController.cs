using Primary_HealthCare_System.Models;
using Asp.NetProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Primary_HealthCare_System.Controllers
{
    //[Authorize(Roles = "Patient")]
    public class ChronicHomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
using Asp.NetProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Primary_HealthCare_System.Controllers
{
	[Authorize]
	public class CounsellingController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CounsellingController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Patient()
		{
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var AlertWelcome = _context.Alerts.Where(a => a.IntendedUser == user && a.Purpose == "Welcome").FirstOrDefault();
			var Alerts = _context.Alerts.Where(a => a.IntendedUser == user).ToList();
			if (AlertWelcome != null)
			{
				ViewBag.Welcome = AlertWelcome;
				TempData["Welcome"] = AlertWelcome.Message;
			}
			if (Alerts.Count > 0)
			{
				ViewBag.Alerts = Alerts;
				TempData["Alerts"] = "Not null";
			}
			return View();
		}
		public IActionResult Counsellor()
		{
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var AlertWelcome = _context.Alerts.Where(a => a.IntendedUser == user && a.Purpose == "Welcome").FirstOrDefault();
			var Alerts = _context.Alerts.Where(a => a.IntendedUser == user).ToList();
			if (AlertWelcome != null)
			{
				ViewBag.Welcome = AlertWelcome;
				TempData["Welcome"] = AlertWelcome.Message;
			}
			if (Alerts.Count > 0)
			{
				ViewBag.Alerts = Alerts;
				TempData["Alerts"] = "Not null";
			}
			return View();
		}

	}
}

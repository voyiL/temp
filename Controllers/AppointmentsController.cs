using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.NetProject.Areas.Identity.Data;
using Primary_HealthCare_System.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace Primary_HealthCare_System.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender emailSender;

        public AppointmentsController(ApplicationDbContext context, IEmailSender _email)
        {
            _context = context;
            emailSender = _email;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            return _context.Appointments != null ?
                        View(await _context.Appointments.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Appointments'  is null.");
        }
        public async Task<IActionResult> My_All_Appointment()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Alerts = _context.Alerts.Where(a => a.IntendedUser == user).ToList();
            if (Alerts.Count > 0)
            {
                ViewBag.Alerts = Alerts;

            }
            ViewBag.AllAppointments = _context.Appointments.Where(a => a.PatientID == user).ToList();
            return View();
        }


        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointments == null)
            {
                return NotFound();
            }

            return View(appointments);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Alerts = _context.Alerts.Where(a => a.IntendedUser == user).ToList();
            ViewBag.Alerts = Alerts;

            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointments appointments)
        {

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            appointments.PatientID = user;
            var Alerts = _context.Alerts.Where(a => a.IntendedUser == user).ToList();
            ViewBag.Alerts = Alerts;
            if (appointments.AppointmentTime != null && appointments.AppointmentTime != null && appointments.clinician != null && appointments.Purpose != null)
            {
                _context.Add(appointments);
                await _context.SaveChangesAsync();
                //after successfully creating the appoint notify the user
                TempData["Success"] = "New Appointment has been Successfully Added";
                //Create alert
                try
                {
                    var alert = new Alert()
                    {
                        Message = "New Appoint has been Created",
                        IntendedUser = user,
                        Purpose = "Notification",

                    };
                    _context.Alerts.Add(alert);
                    await _context.SaveChangesAsync();

                    //Send email
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    await emailSender.SendEmailAsync(email, "New Appointment",

                        $"<html> <head> <style> body {{ font-family: Arial, sans-serif; }} " +
                        $"h1 {{ color: #336699; }}" +
                        $".cta-button {{ background-color: #008CBA; color: white;" +
                        $" padding: 10px 20px;" +
                        $" text-decoration: none; border-radius: 5px; }}" +
                        $".cta-button:hover {{ background-color: #265580; }}" +
                        $".footer {{ margin-top: 20px; font-size: 12px; color: #888; }}" +
                        $"  </style>" +
                        $"</head>" +
                        $"<body>" +
                        $"" +
                        $"<p>Dear Our Loved Patient,</p>" +
                        $"<p>Once again thank you for choosing us, this is a confimation email that your Appointment has been Successfully Created.</p>" +
                        $"<p>If you have any questions or need assistance, please don't hesitate to contact our support team</p>" +
                        $"<div class='footer'>" +
                        $" <p>Thank you,</p>" +
                        $" <p>Healthcare Team</p>" +
                        $"</div>" +
                        $" </body>" +
                        $"</html>");
                    return RedirectToAction(nameof(My_All_Appointment));
                }
                catch (Exception ex) { }


            }
            return View(appointments);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,AppointmentDate,AppointmentTime,Purpose,clinician,Status")] Appointments appointments)
        {
            if (id != appointments.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentsExists(appointments.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointments);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointments == null)
            {
                return NotFound();
            }

            return View(appointments);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Appointments'  is null.");
            }
            var appointments = await _context.Appointments.FindAsync(id);
            if (appointments != null)
            {
                _context.Appointments.Remove(appointments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentsExists(int id)
        {
            return (_context.Appointments?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }


        /// <summary>
        /// Appointments for Counselling
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Counselling()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var Alerts = _context.Alerts.Where(a => a.IntendedUser == user).OrderByDescending(a => a.date).ToList();
            if (Alerts.Count > 0)
            {
                ViewBag.Alerts = Alerts;
                TempData["Alerts"] = "Not null";
            }
            ViewBag.Appointment = _context.Appointments.Where(a => (a.Purpose == "Counselling" && a.PatientID == user)).ToList();
            return View();
        }
		public async Task<IActionResult> Counselling_Appointments()
		{
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var Alerts = _context.Alerts.Where(a => a.IntendedUser == user).OrderByDescending(a => a.date).ToList();
			if (Alerts.Count > 0)
			{
				ViewBag.Alerts = Alerts;
				TempData["Alerts"] = "Not null";
			}
			ViewBag.Appointment = _context.Appointments.Where(a => a.Purpose == "Counselling").Include(a => a.MAinUSer).ToList();
			return View();
		}
		// GET: Appointments/Create
		public IActionResult Counselling_Appointment()
        {
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Counselling_Appointment(Appointments appointments)
        {

            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            appointments.PatientID = user;
            appointments.Purpose = "Counselling";
            if (appointments.AppointmentTime != null && appointments.AppointmentTime != null && appointments.clinician != null && appointments.Purpose != null)
            {
                _context.Add(appointments);
                await _context.SaveChangesAsync();
                //after successfully creating the appoint notify the user
                TempData["Success"] = "New Appointment has been Successfully Added";
                //Create alert
                try
                {
                    var alert = new Alert()
                    {
                        Message = "New Appointment has been Created",
                        IntendedUser = user,
                        Purpose = "Notification",

                    };
                    _context.Alerts.Add(alert);
                    await _context.SaveChangesAsync();

                    //Send email
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    await emailSender.SendEmailAsync(email, "New Appointment",

                        $"<html> <head> <style> body {{ font-family: Arial, sans-serif; }} " +
                        $"h1 {{ color: #336699; }}" +
                        $".cta-button {{ background-color: #008CBA; color: white;" +
                        $" padding: 10px 20px;" +
                        $" text-decoration: none; border-radius: 5px; }}" +
                        $".cta-button:hover {{ background-color: #265580; }}" +
                        $".footer {{ margin-top: 20px; font-size: 12px; color: #888; }}" +
                        $"  </style>" +
                        $"</head>" +
                        $"<body>" +
                        $"" +
                        $"<p>Dear Our Loved Patient,</p>" +
                        $"<p>Once again thank you for choosing us, this is a confimation email that your Appointment has been Successfully Created.</p>" +
                        $"<p>If you have any questions or need assistance, please don't hesitate to contact our support team</p>" +
                        $"<div class='footer'>" +
                        $" <p>Thank you,</p>" +
                        $" <p>Healthcare Team</p>" +
                        $"</div>" +
                        $" </body>" +
                        $"</html>");
                    return RedirectToAction(nameof(Counselling));
                }
                catch (Exception ex) { }


            }
            else
            {
                TempData["Success"] = "Something went Wrong Try Again";
                return RedirectToAction(nameof(Counselling));
            }
            return RedirectToAction(nameof(Counselling));

        }
        // GET: Appointments/Delete/5
        public async Task<IActionResult> Accept_Conselling_Appointment(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var appointments = await _context.Appointments
                    .FirstOrDefaultAsync(m => m.AppointmentId == id);
                appointments.Status = "Accepted";
                _context.Appointments.Update(appointments);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Appointment has been Accepted";
                //Create alert
                var alert = new Alert()
                {
                    Message = "Appointment, dated on "+ appointments.AppointmentCreatedDate+ " has been Accepted by the Consellor",
                    IntendedUser = appointments.PatientID,
                    Purpose = "Notification",

                };
                _context.Alerts.Add(alert);
                await _context.SaveChangesAsync();
                //Send
                //Find the patient Email
                var Pemail = _context.Users.Where(a => a.Id == appointments.PatientID).FirstOrDefault();
                var email = User.FindFirstValue(ClaimTypes.Email);
                await emailSender.SendEmailAsync(Pemail.Email, "Appointment Accepted",

                    $"<html> <head> <style> body {{ font-family: Arial, sans-serif; }} " +
                    $"h1 {{ color: #336699; }}" +
                    $".cta-button {{ background-color: #008CBA; color: white;" +
                    $" padding: 10px 20px;" +
                    $" text-decoration: none; border-radius: 5px; }}" +
                    $".cta-button:hover {{ background-color: #265580; }}" +
                    $".footer {{ margin-top: 20px; font-size: 12px; color: #888; }}" +
                    $"  </style>" +
                    $"</head>" +
                    $"<body>" +
                    $"" +
                    $"<p>Dear Our Loved Patient,</p>" +
                    $"<p>Once again thank you for choosing us, this is a confimation email that your Appointment has been Successfully Accepted.</p>" +
                    $"<p>Be in the look for a Session with the Counsellor</p>" +
                    $"<p>If you have any questions or need assistance, please don't hesitate to contact our support team</p>" +
                    $"<div class='footer'>" +
                    $" <p>Thank you,</p>" +
                    $" <p>Healthcare Team</p>" +
                    $"</div>" +
                    $" </body>" +
                    $"</html>");
                return RedirectToAction(nameof(Counselling_Appointments));

            }
            catch (Exception ex)
            {
                TempData["Success"] = "Something went Wrong Try Again";
                return RedirectToAction(nameof(Counselling_Appointments));
            }

        }  
        public async Task<IActionResult> Delete_Conselling_Appointment(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var appointments = await _context.Appointments
                    .FirstOrDefaultAsync(m => m.AppointmentId == id);
                _context.Appointments.Remove(appointments);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Appointment has been deleted";
                //Create alert
                var alert = new Alert()
                {
                    Message = "Appointment has been Deleted",
                    IntendedUser = user,
                    Purpose = "Notification",

                };
                _context.Alerts.Add(alert);
                await _context.SaveChangesAsync();              
                return RedirectToAction(nameof(Counselling));

            }
            catch (Exception ex)
            {
                TempData["Success"] = "Something went Wrong Try Again";
                return RedirectToAction(nameof(Counselling));
            }

        }

       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.NetProject.Areas.Identity.Data;
using Primary_HealthCare_System.Models;

namespace Primary_HealthCare_System.Controllers
{
    public class RemindersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RemindersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reminders
        public async Task<IActionResult> Index()
        {
              return _context.Reminder != null ? 
                          View(await _context.Reminder.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Reminder'  is null.");
        }

        // GET: Reminders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reminder == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reminder == null)
            {
                return NotFound();
            }

            return View(reminder);
        }

        // GET: Reminders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reminders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientName,MedicationName,ReminderMessage,ReminderTime")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reminder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reminder);
        }

        // GET: Reminders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reminder == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder.FindAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }
            return View(reminder);
        }

        // POST: Reminders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientName,MedicationName,ReminderMessage,ReminderTime")] Reminder reminder)
        {
            if (id != reminder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reminder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReminderExists(reminder.Id))
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
            return View(reminder);
        }

        // GET: Reminders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reminder == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reminder == null)
            {
                return NotFound();
            }

            return View(reminder);
        }

        // POST: Reminders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reminder == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reminder'  is null.");
            }
            var reminder = await _context.Reminder.FindAsync(id);
            if (reminder != null)
            {
                _context.Reminder.Remove(reminder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReminderExists(int id)
        {
          return (_context.Reminder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

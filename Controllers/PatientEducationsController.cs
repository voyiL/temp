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
    public class PatientEducationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientEducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientEducations
        public async Task<IActionResult> Index()
        {
              return _context.PatientEducation != null ? 
                          View(await _context.PatientEducation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PatientEducation'  is null.");
        }

        // GET: PatientEducations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatientEducation == null)
            {
                return NotFound();
            }

            var patientEducation = await _context.PatientEducation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientEducation == null)
            {
                return NotFound();
            }

            return View(patientEducation);
        }

        // GET: PatientEducations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientEducations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Url")] PatientEducation patientEducation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientEducation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientEducation);
        }

        // GET: PatientEducations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatientEducation == null)
            {
                return NotFound();
            }

            var patientEducation = await _context.PatientEducation.FindAsync(id);
            if (patientEducation == null)
            {
                return NotFound();
            }
            return View(patientEducation);
        }

        // POST: PatientEducations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Url")] PatientEducation patientEducation)
        {
            if (id != patientEducation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientEducation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientEducationExists(patientEducation.Id))
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
            return View(patientEducation);
        }

        // GET: PatientEducations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatientEducation == null)
            {
                return NotFound();
            }

            var patientEducation = await _context.PatientEducation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientEducation == null)
            {
                return NotFound();
            }

            return View(patientEducation);
        }

        // POST: PatientEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatientEducation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PatientEducation'  is null.");
            }
            var patientEducation = await _context.PatientEducation.FindAsync(id);
            if (patientEducation != null)
            {
                _context.PatientEducation.Remove(patientEducation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientEducationExists(int id)
        {
          return (_context.PatientEducation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

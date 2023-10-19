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
    public class ReferalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Referals
        public async Task<IActionResult> Index()
        {
              return _context.Referal != null ? 
                          View(await _context.Referal.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Referal'  is null.");
        }

        // GET: Referals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Referal == null)
            {
                return NotFound();
            }

            var referal = await _context.Referal
                .FirstOrDefaultAsync(m => m.ReferralID == id);
            if (referal == null)
            {
                return NotFound();
            }

            return View(referal);
        }

        // GET: Referals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Referals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferralID,CounselingSessionDate,PatientID,ReferralDate,ReferringDoctorID,ReferralReason,AdditionalNotes")] Referal referal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referal);
        }

        // GET: Referals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Referal == null)
            {
                return NotFound();
            }

            var referal = await _context.Referal.FindAsync(id);
            if (referal == null)
            {
                return NotFound();
            }
            return View(referal);
        }

        // POST: Referals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferralID,CounselingSessionDate,PatientID,ReferralDate,ReferringDoctorID,ReferralReason,AdditionalNotes")] Referal referal)
        {
            if (id != referal.ReferralID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferalExists(referal.ReferralID))
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
            return View(referal);
        }

        // GET: Referals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Referal == null)
            {
                return NotFound();
            }

            var referal = await _context.Referal
                .FirstOrDefaultAsync(m => m.ReferralID == id);
            if (referal == null)
            {
                return NotFound();
            }

            return View(referal);
        }

        // POST: Referals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Referal == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Referal'  is null.");
            }
            var referal = await _context.Referal.FindAsync(id);
            if (referal != null)
            {
                _context.Referal.Remove(referal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferalExists(int id)
        {
          return (_context.Referal?.Any(e => e.ReferralID == id)).GetValueOrDefault();
        }
    }
}

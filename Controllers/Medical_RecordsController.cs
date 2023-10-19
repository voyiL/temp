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
    public class Medical_RecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Medical_RecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medical_Records
        public async Task<IActionResult> Index()
        {
              return _context.Medical_Record != null ? 
                          View(await _context.Medical_Record.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Medical_Record'  is null.");
        }

        // GET: Medical_Records/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medical_Record == null)
            {
                return NotFound();
            }

            var medical_Record = await _context.Medical_Record
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (medical_Record == null)
            {
                return NotFound();
            }

            return View(medical_Record);
        }

        // GET: Medical_Records/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medical_Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,ClientID,CounselorID,SessionDate,SessionNotes,IssuesDiscussed,HomeworkAssigned,Progress,FollowUpPlans,NextSessionDate,PatientID,DoctorID,MedicalCondition,Diagnosis,TreatmentPlan,Medications,LabResults,Procedures,FollowUpInstructions,Notes")] Medical_Record medical_Record)
        {
            if (medical_Record.PatientID != null)
            {
                medical_Record.CounselorID = "Dr mullar";
                _context.Add(medical_Record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medical_Record);
        }

        // GET: Medical_Records/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medical_Record == null)
            {
                return NotFound();
            }

            var medical_Record = await _context.Medical_Record.FindAsync(id);
            if (medical_Record == null)
            {
                return NotFound();
            }
            return View(medical_Record);
        }

        // POST: Medical_Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecordID,ClientID,CounselorID,SessionDate,SessionNotes,IssuesDiscussed,HomeworkAssigned,Progress,FollowUpPlans,NextSessionDate,PatientID,DoctorID,MedicalCondition,Diagnosis,TreatmentPlan,Medications,LabResults,Procedures,FollowUpInstructions,Notes")] Medical_Record medical_Record)
        {
            if (id != medical_Record.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medical_Record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Medical_RecordExists(medical_Record.RecordID))
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
            return View(medical_Record);
        }

        // GET: Medical_Records/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medical_Record == null)
            {
                return NotFound();
            }

            var medical_Record = await _context.Medical_Record
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (medical_Record == null)
            {
                return NotFound();
            }

            return View(medical_Record);
        }

        // POST: Medical_Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medical_Record == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medical_Record'  is null.");
            }
            var medical_Record = await _context.Medical_Record.FindAsync(id);
            if (medical_Record != null)
            {
                _context.Medical_Record.Remove(medical_Record);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Medical_RecordExists(int id)
        {
          return (_context.Medical_Record?.Any(e => e.RecordID == id)).GetValueOrDefault();
        }
    }
}

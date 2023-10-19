//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Asp.NetProject.Areas.Identity.Data;
//using Primary_HealthCare_System.Models;

//namespace Primary_HealthCare_System.Controllers
//{
//    public class RefillRequestsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public RefillRequestsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: RefillRequests
//        public async Task<IActionResult> Index()
//        {
//              return _context.RefillRequest != null ? 
//                          View(await _context.RefillRequest.ToListAsync()) :
//                          Problem("Entity set 'ApplicationDbContext.RefillRequest'  is null.");
//        }

//        // GET: RefillRequests/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.RefillRequest == null)
//            {
//                return NotFound();
//            }

//            var refillRequest = await _context.RefillRequest
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (refillRequest == null)
//            {
//                return NotFound();
//            }

//            return View(refillRequest);
//        }

//        // GET: RefillRequests/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: RefillRequests/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Surname,IDnumber,Age,Email,Phone,Medication,Address,Date,IsApproved")] RefillRequest refillRequest)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(refillRequest);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(refillRequest);
//        }

//        // GET: RefillRequests/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.RefillRequest == null)
//            {
//                return NotFound();
//            }

//            var refillRequest = await _context.RefillRequest.FindAsync(id);
//            if (refillRequest == null)
//            {
//                return NotFound();
//            }
//            return View(refillRequest);
//        }

//        // POST: RefillRequests/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,IDnumber,Age,Email,Phone,Medication,Address,Date,IsApproved")] RefillRequest refillRequest)
//        {
//            if (id != refillRequest.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(refillRequest);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RefillRequestExists(refillRequest.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(refillRequest);
//        }

//        // GET: RefillRequests/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.RefillRequest == null)
//            {
//                return NotFound();
//            }

//            var refillRequest = await _context.RefillRequest
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (refillRequest == null)
//            {
//                return NotFound();
//            }

//            return View(refillRequest);
//        }

//        // POST: RefillRequests/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.RefillRequest == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.RefillRequest'  is null.");
//            }
//            var refillRequest = await _context.RefillRequest.FindAsync(id);
//            if (refillRequest != null)
//            {
//                _context.RefillRequest.Remove(refillRequest);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool RefillRequestExists(int id)
//        {
//          return (_context.RefillRequest?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}

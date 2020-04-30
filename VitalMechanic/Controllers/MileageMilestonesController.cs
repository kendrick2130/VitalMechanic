using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VitalMechanic.Data;
using VitalMechanic.Models;

namespace VitalMechanic.Controllers
{
    public class MileageMilestonesController : Controller
    {
        private readonly VehiclesContext _context;

        public MileageMilestonesController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: MileageMilestones
        public async Task<IActionResult> Index()
        {
            return View(await _context.MileageMilestone.ToListAsync());
        }

        // GET: MileageMilestones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mileageMilestone = await _context.MileageMilestone
                .FirstOrDefaultAsync(m => m.Mileageid == id);
            if (mileageMilestone == null)
            {
                return NotFound();
            }

            return View(mileageMilestone);
        }

        // GET: MileageMilestones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MileageMilestones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create([Bind("Mileageid,CarMileage,Milestones")] MileageMilestone mileageMilestone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mileageMilestone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mileageMilestone);
        }

        // GET: MileageMilestones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mileageMilestone = await _context.MileageMilestone.FindAsync(id);
            if (mileageMilestone == null)
            {
                return NotFound();
            }
            return View(mileageMilestone);
        }

        // POST: MileageMilestones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mileageid,CarMileage,Milestones")] MileageMilestone mileageMilestone)
        {
            if (id != mileageMilestone.Mileageid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mileageMilestone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MileageMilestoneExists(mileageMilestone.Mileageid))
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
            return View(mileageMilestone);
        }

        // GET: MileageMilestones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mileageMilestone = await _context.MileageMilestone
                .FirstOrDefaultAsync(m => m.Mileageid == id);
            if (mileageMilestone == null)
            {
                return NotFound();
            }

            return View(mileageMilestone);
        }

        // POST: MileageMilestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mileageMilestone = await _context.MileageMilestone.FindAsync(id);
            _context.MileageMilestone.Remove(mileageMilestone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MileageMilestoneExists(int id)
        {
            return _context.MileageMilestone.Any(e => e.Mileageid == id);
        }
    }
}

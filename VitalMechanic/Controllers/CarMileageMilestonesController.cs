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
    public class CarMileageMilestonesController : Controller
    {
        private readonly VehiclesContext _context;

        public CarMileageMilestonesController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: CarMileageMilestones
        public async Task<IActionResult> Index()
        {
            var vehiclesContext = _context.CarMileageMilestone.Include(c => c.Mileage);
            return View(await vehiclesContext.ToListAsync());
        }

        // GET: CarMileageMilestones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMileageMilestone = await _context.CarMileageMilestone
                .Include(c => c.Mileage)
                .FirstOrDefaultAsync(m => m.UserCarsId == id);
            if (carMileageMilestone == null)
            {
                return NotFound();
            }

            return View(carMileageMilestone);
        }

        // GET: CarMileageMilestones/Create
        public IActionResult Create()
        {
            ViewData["CarMileageMilestoneId"] = new SelectList(_context.Mileage, "CarMileageMilestoneId", "CarMileageMilestoneId");
            return View();
        }

        // POST: CarMileageMilestones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserCarsId,CarMileageMilestoneId,MaintenanceCompletionDate")] CarMileageMilestone carMileageMilestone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carMileageMilestone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarMileageMilestoneId"] = new SelectList(_context.Mileage, "CarMileageMilestoneId", "CarMileageMilestoneId", carMileageMilestone.CarMileageMilestoneId);
            return View(carMileageMilestone);
        }

        // GET: CarMileageMilestones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMileageMilestone = await _context.CarMileageMilestone.FindAsync(id);
            if (carMileageMilestone == null)
            {
                return NotFound();
            }
            ViewData["CarMileageMilestoneId"] = new SelectList(_context.Mileage, "CarMileageMilestoneId", "CarMileageMilestoneId", carMileageMilestone.CarMileageMilestoneId);
            return View(carMileageMilestone);
        }

        // POST: CarMileageMilestones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserCarsId,CarMileageMilestoneId,MaintenanceCompletionDate")] CarMileageMilestone carMileageMilestone)
        {
            if (id != carMileageMilestone.UserCarsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carMileageMilestone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarMileageMilestoneExists(carMileageMilestone.UserCarsId))
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
            ViewData["CarMileageMilestoneId"] = new SelectList(_context.Mileage, "CarMileageMilestoneId", "CarMileageMilestoneId", carMileageMilestone.CarMileageMilestoneId);
            return View(carMileageMilestone);
        }

        // GET: CarMileageMilestones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMileageMilestone = await _context.CarMileageMilestone
                .Include(c => c.Mileage)
                .FirstOrDefaultAsync(m => m.UserCarsId == id);
            if (carMileageMilestone == null)
            {
                return NotFound();
            }

            return View(carMileageMilestone);
        }

        // POST: CarMileageMilestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carMileageMilestone = await _context.CarMileageMilestone.FindAsync(id);
            _context.CarMileageMilestone.Remove(carMileageMilestone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarMileageMilestoneExists(int id)
        {
            return _context.CarMileageMilestone.Any(e => e.UserCarsId == id);
        }
    }
}

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
    public class CarYearsController : Controller
    {
        private readonly VehiclesContext _context;

        public CarYearsController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: CarYears
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarYear.ToListAsync());
        }

        // GET: CarYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carYear = await _context.CarYear
                .FirstOrDefaultAsync(m => m.CarYearId == id);
            if (carYear == null)
            {
                return NotFound();
            }

            return View(carYear);
        }

        // GET: CarYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarYearId,YearOfMake")] CarYear carYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carYear);
        }

        // GET: CarYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carYear = await _context.CarYear.FindAsync(id);
            if (carYear == null)
            {
                return NotFound();
            }
            return View(carYear);
        }

        // POST: CarYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarYearId,YearOfMake")] CarYear carYear)
        {
            if (id != carYear.CarYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarYearExists(carYear.CarYearId))
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
            return View(carYear);
        }

        // GET: CarYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carYear = await _context.CarYear
                .FirstOrDefaultAsync(m => m.CarYearId == id);
            if (carYear == null)
            {
                return NotFound();
            }

            return View(carYear);
        }

        // POST: CarYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carYear = await _context.CarYear.FindAsync(id);
            _context.CarYear.Remove(carYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarYearExists(int id)
        {
            return _context.CarYear.Any(e => e.CarYearId == id);
        }
    }
}

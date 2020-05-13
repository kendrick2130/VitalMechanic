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
    public class CarModelsController : Controller
    {
        private readonly VehiclesContext _context;

        public CarModelsController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: CarModels
        public async Task<IActionResult> Index()
        {
            var vehiclesContext = _context.CarModels.Include(c => c.Make);
            return View(await vehiclesContext.ToListAsync());
        }

        // GET: CarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels
                .Include(c => c.Make)
                .FirstOrDefaultAsync(m => m.CarModelsId == id);
            if (carModels == null)
            {
                return NotFound();
            }

            return View(carModels);
        }

        // GET: CarModels/Create
        public IActionResult Create()
        {
            ViewData["CarMakesId"] = new SelectList(_context.CarMakes, "CarMakesId", "Make");
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarModelsId,Model,CarMakesId")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarMakesId"] = new SelectList(_context.CarMakes, "CarMakesId", "Make", carModels.CarMakesId);
            return View(carModels);
        }

        // GET: CarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels.FindAsync(id);
            if (carModels == null)
            {
                return NotFound();
            }
            ViewData["CarMakesId"] = new SelectList(_context.CarMakes, "CarMakesId", "Make", carModels.CarMakesId);
            return View(carModels);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarModelsId,Model,CarMakesId")] CarModels carModels)
        {
            if (id != carModels.CarModelsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelsExists(carModels.CarModelsId))
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
            ViewData["CarMakesId"] = new SelectList(_context.CarMakes, "CarMakesId", "Make", carModels.CarMakesId);
            return View(carModels);
        }

        // GET: CarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModels = await _context.CarModels
                .Include(c => c.Make)
                .FirstOrDefaultAsync(m => m.CarModelsId == id);
            if (carModels == null)
            {
                return NotFound();
            }

            return View(carModels);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModels = await _context.CarModels.FindAsync(id);
            _context.CarModels.Remove(carModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelsExists(int id)
        {
            return _context.CarModels.Any(e => e.CarModelsId == id);
        }
    }
}

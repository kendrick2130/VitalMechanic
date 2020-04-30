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
    public class CarMakesController : Controller
    {
        private readonly VehiclesContext _context;

        public CarMakesController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: CarMakes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarMakes.ToListAsync());
        }

        // GET: CarMakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMakes = await _context.CarMakes
                .FirstOrDefaultAsync(m => m.MakeId == id);
            if (carMakes == null)
            {
                return NotFound();
            }

            return View(carMakes);
        }

        // GET: CarMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MakeId,Make")] CarMakes carMakes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carMakes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carMakes);
        }

        // GET: CarMakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMakes = await _context.CarMakes.FindAsync(id);
            if (carMakes == null)
            {
                return NotFound();
            }
            return View(carMakes);
        }

        // POST: CarMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MakeId,Make")] CarMakes carMakes)
        {
            if (id != carMakes.MakeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carMakes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarMakesExists(carMakes.MakeId))
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
            return View(carMakes);
        }

        // GET: CarMakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMakes = await _context.CarMakes
                .FirstOrDefaultAsync(m => m.MakeId == id);
            if (carMakes == null)
            {
                return NotFound();
            }

            return View(carMakes);
        }

        // POST: CarMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carMakes = await _context.CarMakes.FindAsync(id);
            _context.CarMakes.Remove(carMakes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarMakesExists(int id)
        {
            return _context.CarMakes.Any(e => e.MakeId == id);
        }
    }
}

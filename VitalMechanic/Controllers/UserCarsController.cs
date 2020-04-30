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
    public class UserCarsController : Controller
    {
        private readonly VehiclesContext _context;

        public UserCarsController(VehiclesContext context)
        {
            _context = context;
        }

        // GET: UserCars
        public async Task<IActionResult> Index()
        {
            var vehiclesContext = _context.UserCars.Include(u => u.Model).Include(u => u.User).Include(u => u.YearMake);
            return View(await vehiclesContext.ToListAsync());
        }

        // GET: UserCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCars = await _context.UserCars
                .Include(u => u.Model)
                .Include(u => u.User)
                .Include(u => u.YearMake)
                .FirstOrDefaultAsync(m => m.UserCarId == id);
            if (userCars == null)
            {
                return NotFound();
            }

            return View(userCars);
        }

        // GET: UserCars/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.CarModels, "ModelId", "Model");
            ViewData["UserId"] = new SelectList(_context.UserloginTbl, "UserId", "UserId");
            ViewData["YearMakeId"] = new SelectList(_context.CarYear, "YearMakeId", "YearMakeId");
            return View();
        }

        // POST: UserCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserCarId,UserId,ModelId,YearMakeId")] UserCars userCars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.CarModels, "ModelId", "Model", userCars.ModelId);
            ViewData["UserId"] = new SelectList(_context.UserloginTbl, "UserId", "UserId", userCars.UserId);
            ViewData["YearMakeId"] = new SelectList(_context.CarYear, "YearMakeId", "YearMakeId", userCars.YearMakeId);
            return View(userCars);
        }

        // GET: UserCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCars = await _context.UserCars.FindAsync(id);
            if (userCars == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.CarModels, "ModelId", "Model", userCars.ModelId);
            ViewData["UserId"] = new SelectList(_context.UserloginTbl, "UserId", "UserId", userCars.UserId);
            ViewData["YearMakeId"] = new SelectList(_context.CarYear, "YearMakeId", "YearMakeId", userCars.YearMakeId);
            return View(userCars);
        }

        // POST: UserCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserCarId,UserId,ModelId,YearMakeId")] UserCars userCars)
        {
            if (id != userCars.UserCarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCarsExists(userCars.UserCarId))
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
            ViewData["ModelId"] = new SelectList(_context.CarModels, "ModelId", "Model", userCars.ModelId);
            ViewData["UserId"] = new SelectList(_context.UserloginTbl, "UserId", "UserId", userCars.UserId);
            ViewData["YearMakeId"] = new SelectList(_context.CarYear, "YearMakeId", "YearMakeId", userCars.YearMakeId);
            return View(userCars);
        }

        // GET: UserCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCars = await _context.UserCars
                .Include(u => u.Model)
                .Include(u => u.User)
                .Include(u => u.YearMake)
                .FirstOrDefaultAsync(m => m.UserCarId == id);
            if (userCars == null)
            {
                return NotFound();
            }

            return View(userCars);
        }

        // POST: UserCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userCars = await _context.UserCars.FindAsync(id);
            _context.UserCars.Remove(userCars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCarsExists(int id)
        {
            return _context.UserCars.Any(e => e.UserCarId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VitalMechanic.Data;
using VitalMechanic.Models;

namespace VitalMechanic.Controllers
{
    public class CarGarageController : Controller
    {
        //private readonly VehiclesContext _context;

        //public CarGarageController(VehiclesContext context)
        //{
        //    _context = context;
                
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(CarGarage cg)
        //{
        //    _context.Add(cg);
        //    _context.SaveChanges();
        //    ViewBag.message = "The Selected Vehicle" + cg.Make + "Is saved Successfully!";
        //    return View();
        //}
    }
}
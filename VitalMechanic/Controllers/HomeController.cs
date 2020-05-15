using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VitalMechanic.Data;
using VitalMechanic.Models;


namespace VitalMechanic.Controllers
{
    public class HomeController : Controller
    {        
        private readonly VehiclesContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, VehiclesContext context)
        {
            _logger = logger;
            _context = context;
          
        }
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> DisplayMileStone(VehicleMiles miles, MileStones stones)
        //{
        //    if (miles.Mileage <= stones.VehicleMileStones)
        //    {
        //        Console.WriteLine(stones.MileStoneDescription);
        //    }

        //    return RedirectToAction(nameof(Dashboard));
        //}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> StoreMileage(int miles, CarGarage selectedCar)
        {
            selectedCar = _context.CarGarage.Find(selectedCar.CarGarageID);
            MileStones stones = new MileStones();

            VehicleMiles mileage = new VehicleMiles();
            mileage.Mileage = miles;
            mileage.CarGarageID = selectedCar.CarGarageID;

            if (miles == 0)
            {
                HttpContext.Session.SetString("message", "Please enter a valid number");
            }
            else
            {
                _context.VehicleMiles.Add(mileage);
               
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Dashboard));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Dashboard(CarGarage cg)
        {

            _context.CarGarage.Add(cg);
            _context.SaveChanges();
            //ViewBag.message = "The Selected Vehicle" + cg.Make + "Is saved Successfully!";
            return RedirectToAction();
        }

        [Authorize] 
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            VehiclesContext vehicleMake = new VehiclesContext();
            var getCarMakeList = await vehicleMake.CarMakes.ToListAsync();

            VehiclesContext vehicleModel = new VehiclesContext();
            var getCarModelList = await vehicleModel.CarModels.ToListAsync();

            VehiclesContext vehicleYear = new VehiclesContext();
            var getCarYearList = await vehicleYear.CarYear.ToListAsync();

            VehiclesContext vehicleDrive = new VehiclesContext();
            var getDriveTranList = await vehicleDrive.DriveTrans.ToListAsync();

            VehiclesContext vehicleEngine = new VehiclesContext();
            var getEngineSizeList = await vehicleEngine.EngineSizes.ToListAsync();

            VehiclesContext vehicleTrans = new VehiclesContext();
            var getTransmissionList = await vehicleTrans.Transmissions.ToListAsync();


            SelectList list1 = new SelectList(getCarMakeList, "Make", "Make");
            ViewBag.carMakeList = list1;

            SelectList list2 = new SelectList(getCarModelList, "CarModelsId", "Model");
            ViewBag.carModelList = list2;

            SelectList list3 = new SelectList(getCarYearList, "YearOfMake", "YearOfMake");
            ViewBag.carYearList = list3;

            SelectList list4 = new SelectList(getDriveTranList, "DriveTranType", "DriveTranType");
            ViewBag.carDriveList = list4;

            SelectList list5 = new SelectList(getEngineSizeList, "EngineType", "EngineType");
            ViewBag.carEngineList = list5;

            SelectList list6 = new SelectList(getTransmissionList, "TransmissionType", "TransmissionType");
            ViewBag.carTransmissionList = list6;

            VehiclesContext carGarage = new VehiclesContext();
            var getCarGarageList = await carGarage.CarGarage.ToListAsync();

            SelectList garagelist1 = new SelectList(getCarGarageList, "CarGarageID", "CarModels");
            ViewBag.carGarageList = garagelist1;
           
            ViewBag.message = HttpContext.Session.GetString("message");

            return View();
        }      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
        //public async Task<IActionResult> StoreMileage(int miles, CarGarage selectedCar)
        //{
        //    selectedCar = _context.CarGarage.Find(selectedCar.CarGarageID);           

        //    VehicleMiles mileage = _context.VehicleMiles.SingleOrDefault(vm => vm.CarGarageID == selectedCar.CarGarageID); // compares the IDs to eachother. If they are equal then update, if not then add. 

        //    if (mileage == null)
        //    {
        //        mileage = new VehicleMiles
        //        {
        //            CarGarageID = selectedCar.CarGarageID
        //        };
        //        _context.VehicleMiles.Add(mileage);
        //    }

        //    mileage.Mileage = miles;

        //    if (miles == 0)
        //    {
        //        HttpContext.Session.SetString("message", "Please enter a valid number");
        //    }
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Dashboard));
        //}

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Dashboard(int miles = 0, int car = 0)
        {
            await SetupDashboard();

            DashboardViewModel query = null;

            if (miles == 0 && car != 0)
            {
                ViewBag.Message = "Please enter a valid number";
            }
            else if (miles != 0 && car != 0)
            {
                var selectedCar = _context.CarGarage
                                          .Include(cg => cg.CarModels)
                                          .SingleOrDefault(cg => cg.CarGarageID == car);

                query = new DashboardViewModel(
                                selectedCar.CarModels.Model, miles,
                                _context.MileStones
                                        .Where(ms => ms.VehicleMileStones <= miles)
                                        .Select(ms => new VehicleMilestoneViewModel(ms.VehicleMileStones,           ms.MileStoneDescription)));
            }

            return View(query);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Dashboard(CarGarage cg)
        {
            _context.CarGarage.Add(cg);
            _context.SaveChanges();
            return RedirectToAction();
        }

        private async Task SetupDashboard()
        {
            var getCarMakeList = await _context.CarMakes.ToListAsync();
            var getCarModelList = await _context.CarModels.ToListAsync();
            var getCarYearList = await _context.CarYear.ToListAsync();
            var getDriveTranList = await _context.DriveTrans.ToListAsync();
            var getEngineSizeList = await _context.EngineSizes.ToListAsync();
            var getTransmissionList = await _context.Transmissions.ToListAsync();

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

            var getCarGarageList = await _context.CarGarage.Include(cg => cg.CarModels).ToListAsync(); //gets carGarage and navigation property (carModels).

            SelectList garagelist1 = new SelectList(getCarGarageList, "CarGarageID", "CarModels.Model");
            ViewBag.carGarageList = garagelist1;
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

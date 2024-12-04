using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using VehicleEfficiencyAcd.Business.Operations.Vehicle;
using VehicleEfficiencyAcd.Business.Operations.VehicleUsage;
using VehicleEfficiencyAcd.Business.Operations.VehicleUsage.Dtos;
using VehicleEfficiencyAcd.Presentation.Models.VehicleUsage;
using VehicleEfficiencyAcd.Presentation.SignalR;

namespace VehicleEfficiencyAcd.Presentation.Controllers
{
    public class VehicleUsageController : Controller
    {
        // ▼ Calling services from business layer with constructor dependency injection below ▼
        private readonly IVehicleUsageService _vehicleUsageService;
        private readonly IVehicleService _vehicleService;

        private readonly IHubContext<VehiclePerformanceHub> _hubContext;

        public VehicleUsageController(IVehicleUsageService vehicleUsageService, IVehicleService vehicleService, IHubContext<VehiclePerformanceHub> hubContext)
        {
            _vehicleUsageService = vehicleUsageService;
            _vehicleService = vehicleService;
            _hubContext = hubContext;
        }

        #region GET : ViewAll
        [Authorize(Roles = "Admin")] // -> In project instruction users can't view vehicles performance and graphics as mission 3
        [HttpGet]
        public async Task<IActionResult> ViewAll(int page = 1, int pageSize = 10)
        {
            var serviceResult = await _vehicleUsageService.GetAllWithPages(page, pageSize);

            if (serviceResult.IsSucceed is false)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(new VehicleUsageListViewModel()); // -> If data is null sending 
            }

            // ▼ Convert DTOs (vehicledto,vehiclelistdto) from business layer to presentation ViewModels ▼
            var vehicleUsageViewModels = serviceResult.Data.VehicleUsages.Select(vu => new VehicleUsageViewModel
            {
                Id = vu.Id,
                VehicleId = vu.VehicleId,
                VehicleName = vu.VehicleName,
                VehiclePlate = vu.VehiclePlate,
                VehicleImagePath = vu.VehicleImagePath,
                ActiveHours = vu.ActiveHours,
                MaintenanceHours = vu.MaintenanceHours,
                Week = vu.Week,

                TotalHours = 168, // Fixed total hours for a week
                WorkHours = vu.ActiveHours + vu.MaintenanceHours, // Work hours = Active + Maintenance
                IdleHours = 168 - (vu.ActiveHours + vu.MaintenanceHours) // Idle hours = Total Hours - Work Hours

            }).ToList();

            var vehicleUsageListViewModel = new VehicleUsageListViewModel
            {
                VehicleUsages = vehicleUsageViewModels,
                CurrentPage = serviceResult.Data.CurrentPage,
                TotalPages = serviceResult.Data.TotalPages
            };

            return View(vehicleUsageListViewModel);
        }
        #endregion

        #region GET: VehicleUsage/Add
        [Authorize] // -> In project instruction users can add work hours of vehicle as mission 2
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var vehicleServiceResult = await _vehicleService.GetAll();

            if (vehicleServiceResult.IsSucceed is false)
            {
                ViewBag.ErrorMessage = vehicleServiceResult.Message;
                return View();
            }

            var vehicleSelectList = vehicleServiceResult.Data.Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = $"{v.Name} - {v.Plate}"
            }).ToList();

            var model = new AddVehicleUsageViewModel
            {
                Vehicles = vehicleSelectList
            };

            return View(model);
        }
        #endregion

        #region POST: VehicleUsage/Add
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddVehicleUsageRequest model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add");
            }

            // I calculated idle hours in my logics, not iddlehours column in database cause its calculation
            double idleHours = (7 * 24) - (model.ActiveHours + model.MaintenanceHours);

            // Prepare the DTO for adding the vehicle usage
            var vehicleUsageDto = new AddVehicleUsageDto
            {
                VehicleId = model.VehicleId, // Assuming model.VehicleId is the plate, adjust if necessary
                ActiveHours = model.ActiveHours,
                MaintenanceHours = model.MaintenanceHours,
                Week = model.Week
            };

            // Call the service to add the vehicle usage
            var serviceResult = await _vehicleUsageService.AddVehicleUsage(vehicleUsageDto);

            if (serviceResult.IsSucceed is false)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(model);
            }

            return RedirectToAction("PerformanceInsight");
        }
        #endregion

        #region GET: VehicleUsage/Edit/{id}
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var vehicleUsageServiceResult = await _vehicleUsageService.GetById(id);

            if (vehicleUsageServiceResult.IsSucceed is false || vehicleUsageServiceResult.Data == null)
            {
                return NotFound();
            }

            var vehicleUsage = vehicleUsageServiceResult.Data;

            // Fetch vehicles for the dropdown list
            var vehiclesResult = await _vehicleService.GetAllWithPages(1, 100);  // Modify the page and page size if needed
            if (vehiclesResult.IsSucceed is false || vehiclesResult.Data == null)
            {
                ViewBag.ErrorMessage = "No vehicles found to display.";
                return View(vehicleUsage);
            }

            // Build a list of vehicles for the dropdown
            var vehicleSelectList = vehiclesResult.Data.Vehicles.Select(v => new SelectListItem
            {
                Value = v.Id.ToString(),
                Text = $"{v.Name} - {v.Plate}"
            }).ToList();


            // Prepare the view model for editing
            var model = new EditVehicleUsageViewModel
            {
                Id = vehicleUsage.Id,
                VehicleId = vehicleUsage.VehicleId,
                ActiveHours = vehicleUsage.ActiveHours,
                MaintenanceHours = vehicleUsage.MaintenanceHours,
                Week = vehicleUsage.Week,
                Vehicles = vehicleSelectList
            };

            return View(model);
        }
        #endregion

        #region POST: VehicleUsage/Edit/{id}
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditVehicleUsageRequest model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }

            var vehicleUsageDto = new EditVehicleUsageDto
            {
                Id = model.Id,
                VehicleId = model.VehicleId,
                ActiveHours = model.ActiveHours,
                MaintenanceHours = model.MaintenanceHours,
                Week = model.Week,
            };

            var serviceResult = await _vehicleUsageService.UpdateVehicleUsage(vehicleUsageDto);

            if (serviceResult.IsSucceed is false)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(serviceResult);
            }

            return RedirectToAction("ViewAll");
        }
        #endregion

        #region POST: VehicleUsage/Delete/{id}
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceResult = await _vehicleUsageService.DeleteVehicleUsage(id);

            if (!serviceResult.IsSucceed)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return RedirectToAction("ViewAll");
            }

            return RedirectToAction("ViewAll");
        }
        #endregion

        #region GET : PerformanceInsight
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PerformanceInsight()
        {
            var serviceResult = await _vehicleUsageService.GetAll();

            if (serviceResult.IsSucceed is false)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(new PerformanceInsightViewModel()); // If no data, return an empty view model
            }

            // Prepare data for the performance insights (bar chart)
            var vehiclePerformanceData = serviceResult.Data
                .GroupBy(vu => vu.VehicleId)
                .Select(vg => new PerformanceInsightCardViewModel
                {
                    VehicleId = vg.Key,
                    VehicleName = vg.FirstOrDefault().VehicleName,  // Assumes all items have the same vehicle name
                    VehiclePlate = vg.FirstOrDefault().VehiclePlate,  // Assumes all items have the same vehicle plate
                    VehicleImagePath = vg.FirstOrDefault().VehicleImagePath,  // Assumes all items have the same vehicle image path
                    WeeklyData = vg.Select(vu => new WeeklyPerformanceData
                    {
                        Week = vu.Week,
                        TotalHours = 168, // Fixed total hours for a week
                        ActiveHours = vu.ActiveHours,
                        MaintenanceHours = vu.MaintenanceHours,
                        Ratio = ((vu.ActiveHours + vu.MaintenanceHours) / 168) // Active hours ratio for the week
                    }).ToList()
                }).ToList();

            var model = new PerformanceInsightViewModel
            {
                VehiclePerformanceData = vehiclePerformanceData
            };

            return View(model);
        }
        #endregion

        #region SignalR
        //// ▼ I made this part for using SignalR but for now I did not use on this project ▼
        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> UpdateVehiclePerformanceData()
        //{

        //    // Notify clients about the update
        //    await _hubContext.Clients.All.SendAsync("ReceiveChartDataUpdate");

        //    return Ok();
        //}
        #endregion
    }

}

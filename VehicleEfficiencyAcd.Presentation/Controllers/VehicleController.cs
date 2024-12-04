using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VehicleEfficiencyAcd.Business.Operations.Vehicle;
using VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos;
using VehicleEfficiencyAcd.Presentation.Models.Vehicle;

namespace VehicleEfficiencyAcd.Presentation.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService; // -> Using Vehicle Service with dependency injection in ctor

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        #region GET : ViewAll
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ViewAll(int page = 1, int pageSize = 9)
        {
            var serviceResult = await _vehicleService.GetAllWithPages(page, pageSize);

            if (!serviceResult.IsSucceed)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(new VehicleListDto()); // If data is null return empty
            }

            // Firstly I took vehicledto list to vehicleviewmodel ( DTO on business side, Viewmodal on presenation side for good single responsibility architecthure )
            var vehicleViewModels = serviceResult.Data.Vehicles.Select(v => new VehicleViewModel
            {
                Id = v.Id,
                Name = v.Name,
                Plate = v.Plate,
                CreatedDate = v.CreatedDate,
                ModifiedDate = v.ModifiedDate,
                ImagePath = v.ImagePath
            }).ToList();

            // Secondly with viewmodals create a list view model with pagination datas as well
            var vehicleListViewModel = new VehicleListViewModel
            {
                Vehicles = vehicleViewModels,
                CurrentPage = serviceResult.Data.CurrentPage,
                TotalPages = serviceResult.Data.TotalPages
            };

            return View(vehicleListViewModel);

        }
        #endregion

        #region GET: Add
        [Authorize(Roles = "Admin")] // -> In project instruction users can't add  vehicle as mission 1
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        #endregion

        #region POST: Add
        [Authorize(Roles = "Admin")] // -> In project instruction users can't add  vehicle as mission 1
        [HttpPost]
        public async Task<IActionResult> Add(AddRequest addRequest, IFormFile imageFile)
        {
            if (!ModelState.IsValid)  // -> Checking model states that I defined in Models.AddRequest
            {
                return View(addRequest);
            }

            string imagePath = null;

            // File upload logic
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/vehicles");

                // Ensure the directory exists 
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Save the file to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Relative path for storing in the database
                imagePath = $"/images/vehicles/{fileName}";
            }

            var vehicleDto = new AddVehicleDto
            {
                Name = addRequest.Name,
                Plate = addRequest.Plate,
                ImagePath = imagePath
            };

            var serviceResult = await _vehicleService.AddVehicle(vehicleDto);

            if (!serviceResult.IsSucceed)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(serviceResult);
            }

            return RedirectToAction("Index", "Home");

        }
        #endregion

        #region POST: Delete
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceResult = await _vehicleService.DeleteVehicle(id);

            if (!serviceResult.IsSucceed)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("ViewAll");
            }

        }
        #endregion

        #region GET: Edit
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var serviceResult = await _vehicleService.GetById(id);

            if (serviceResult.IsSucceed is false)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return RedirectToAction("ViewAll");
            }

            var editRequest = new EditRequest
            {
                Id = id,
                Name = serviceResult.Data.Name,
                Plate = serviceResult.Data.Plate,
                ImagePath = serviceResult.Data.ImagePath
            };

            return View(editRequest);
        }
        #endregion

        #region POST: Edit
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditRequest editRequest, IFormFile newImageFile)
        {

            if (newImageFile != null && newImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/vehicles");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await newImageFile.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(editRequest.ImagePath))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", editRequest.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                editRequest.ImagePath = $"/images/vehicles/{fileName}";
            }
            else
            {
                ModelState.Remove("newImageFile");
                editRequest.ImagePath = editRequest.ImagePath ?? string.Empty;
            }


            if (!ModelState.IsValid)
            {
                return View(editRequest);
            }

            var editVehicleDto = new EditVehicleDto
            {
                Id = editRequest.Id,
                Name = editRequest.Name,
                Plate = editRequest.Plate,
                ImagePath = editRequest.ImagePath
            };

            var serviceResult = await _vehicleService.UpdateVehicle(editVehicleDto);

            if (serviceResult.IsSucceed is false)
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(editRequest);
            }

            return RedirectToAction("ViewAll");
        }
        #endregion

    }
}

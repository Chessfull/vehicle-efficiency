using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos;
using VehicleEfficiencyAcd.Business.Types;
using VehicleEfficiencyAcd.Data.Entities;
using VehicleEfficiencyAcd.Data.Repositories;
using VehicleEfficiencyAcd.Data.UnitOfWork;

namespace VehicleEfficiencyAcd.Business.Operations.Vehicle
{
    public class VehicleManager : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork; // -> Calling UOW for transactions, async saves ...
        private readonly IRepository<VehicleEntity> _vehicleRepository; // -> I defined my repository as generic so in VehicleManager T= VehicleEntity

        // Ctor dependency injection
        public VehicleManager(IUnitOfWork unitOfWork, IRepository<VehicleEntity> repository)
        {
            // Constructor Injection Here
            _unitOfWork = unitOfWork;
            _vehicleRepository = repository;
        }

        #region Adding Vehicle Operations
        public async Task<ServiceMessage> AddVehicle(AddVehicleDto entity)
        {
            var vehicleCheck = _vehicleRepository.GetAll(v => v.Plate.ToLower() == entity.Plate.ToLower()); // -> Checking vehicle from plate is already in our database or not

            if (vehicleCheck.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = $"Sorry, this plate {entity.Plate} is already defined..."
                };
            }

            var vehicleEntity = new VehicleEntity // -> For adding database I need VehicleEntity so 'DTO to Entity' single responsibility
            {
                Name = entity.Name,
                Plate = entity.Plate,
                ImagePath = entity.ImagePath
            };

            _vehicleRepository.Add(vehicleEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync(); // -> Saving database with UOW
            }
            catch (Exception)
            {
                throw new Exception("There is a mistake along vehicle registration");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Vehicle is successfully added."
            };
        }
        #endregion

        #region Deleting Vehicle Operations
        public async Task<ServiceMessage> DeleteVehicle(int id)
        {
            var deletedVehicle = _vehicleRepository.GetById(id); // -> finding deleted vehicle with id by repository 

            if (deletedVehicle == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "The vehicle you want to delete is not found ..."
                };
            }

            _vehicleRepository.Delete(deletedVehicle);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("There is a error while deleting vehicle ...");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Delete process is succesfull ..."
            };
        }
        #endregion

        #region Getall Vehicles ( with page infos for pagination )
        public async Task<ServiceMessage<VehicleListDto>> GetAllWithPages(int page, int pageSize)
        {


            var vehiclesQuery = _vehicleRepository.GetAll(v => v.IsDeleted == false); // Get vehicles with exclude softdeleted

            var totalCount = await _vehicleRepository.Count(v => v.IsDeleted == false); // Get count with exclude softdeleted vehicles

            if (totalCount == 0)
            {
                return new ServiceMessage<VehicleListDto>
                {
                    IsSucceed = false,
                    Message = "No vehicles found...",
                    Data = null
                };
            }

            // This part for pagination
            var vehicles = await vehiclesQuery
            .OrderBy(v => v.Name) // Sort by name
            .Skip((page - 1) * pageSize) // Skip records based on page and page size
            .Take(pageSize) // Take the records for the current page
            .ToListAsync();

            // Entity to DTO for ListDto
            var vehicleDtos = vehicles.Select(v => new VehicleDto
            {
                Id = v.Id,
                Name = v.Name,
                Plate = v.Plate,
                CreatedDate = v.CreatedDate,
                ModifiedDate = v.ModifiedDate,
                ImagePath = v.ImagePath
            }).ToList();

            // Now I used dtos to turn listDto for with pagination infos
            var resultDto = new VehicleListDto
            {
                Vehicles = vehicleDtos,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize) // -> Total count I defined above with exclude softdeleted
            };

            return new ServiceMessage<VehicleListDto>
            {
                IsSucceed = true,
                Data = resultDto
            };

        }
        #endregion

        #region Get Vehicle
        public async Task<ServiceMessage<List<VehicleDto>>> GetAll()
        {
            var vehiclesQuery = _vehicleRepository.GetAll(v => v.IsDeleted == false); // For excluding softdeleted vehicles

            var vehicles = await vehiclesQuery
                .OrderBy(v => v.Name)
                .ToListAsync();

            // Convert entities to DTOs
            var vehicleDtos = vehicles.Select(v => new VehicleDto
            {
                Id= v.Id,
                Name = v.Name,
                Plate = v.Plate,
                CreatedDate = v.CreatedDate,
                ModifiedDate = v.ModifiedDate
            }).ToList();

            return new ServiceMessage<List<VehicleDto>>
            {
                IsSucceed = true,
                Data = vehicleDtos
            };
        }
        #endregion

        #region Get Vehicle ById
        public async Task<ServiceMessage<EditVehicleDto>> GetById(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return new ServiceMessage<EditVehicleDto>
                {
                    IsSucceed = false,
                    Message = "The Vehicle you are trying to find is not found...",
                    Data = null
                };
            }

            return new ServiceMessage<EditVehicleDto>
            {
                IsSucceed = true,
                Data = new EditVehicleDto
                {
                    Name = vehicle.Name,
                    Plate = vehicle.Plate,
                    ImagePath = vehicle.ImagePath
                }
            };
        }
        #endregion

        #region Update Vehicle Operations
        public async Task<ServiceMessage> UpdateVehicle(EditVehicleDto vehicleDto)
        {
            
            var vehicleEntity = _vehicleRepository.GetById(vehicleDto.Id);

            if (vehicleEntity == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Vehicle not found."
                };
            }

            vehicleEntity.Name = vehicleDto.Name;
            vehicleEntity.Plate = vehicleDto.Plate;
            vehicleEntity.ImagePath = vehicleDto.ImagePath; 

            try
            {
                await _unitOfWork.SaveChangesAsync(); // Save changes via UnitOfWork
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Vehicle updated successfully..."
                };
            }
            catch (Exception ex)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = $"Error while updating vehicle: {ex.Message}"
                };
            }
        }
        #endregion

    }
}
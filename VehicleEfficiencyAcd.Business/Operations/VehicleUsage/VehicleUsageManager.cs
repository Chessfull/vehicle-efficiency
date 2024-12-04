using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos;
using VehicleEfficiencyAcd.Business.Operations.VehicleUsage.Dtos;
using VehicleEfficiencyAcd.Business.Types;
using VehicleEfficiencyAcd.Data.Entities;
using VehicleEfficiencyAcd.Data.Repositories;
using VehicleEfficiencyAcd.Data.UnitOfWork;

namespace VehicleEfficiencyAcd.Business.Operations.VehicleUsage
{
    public class VehicleUsageManager : IVehicleUsageService
    {
        private readonly IUnitOfWork _unitOfWork; // -> Calling UOW for transactions, async saves ...
        private readonly IRepository<VehicleUsageEntity> _vehicleUsageRepository; // -> I defined my repository as generic so in VehicleUsageManager T= VehicleUsageEntity
        private readonly IRepository<VehicleEntity> _vehicleRepository;

        // Ctor dependency injection
        public VehicleUsageManager(IRepository<VehicleUsageEntity> vehicleUsageRepository, IRepository<VehicleEntity> vehicleRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _vehicleUsageRepository = vehicleUsageRepository;
            _vehicleRepository = vehicleRepository;
        }

        #region Add Operations
        public async Task<ServiceMessage> AddVehicleUsage(AddVehicleUsageDto vehicleUsageDto)
        {
            var vehicleUsageEntity = new VehicleUsageEntity // -> Receive from post endpoint and as dto from controller to service here saving as entity in repository
            {
                VehicleId = vehicleUsageDto.VehicleId,
                ActiveHours = vehicleUsageDto.ActiveHours,
                MaintenanceHours = vehicleUsageDto.MaintenanceHours,
                Week = vehicleUsageDto.Week
            };

            _vehicleUsageRepository.Add(vehicleUsageEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = $"Error while adding vehicle usage: {ex.Message}"
                };
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Vehicle usage added successfully."
            };
        }
        #endregion

        #region Get All Vehicle Usages ( with page infos for pagination )
        public async Task<ServiceMessage<VehicleUsageListDto>> GetAllWithPages(int page, int pageSize)
        {
            var totalRecords = await _vehicleUsageRepository.Count();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var vehicleUsages = await _vehicleUsageRepository
                .GetAll()
                .Include(vu => vu.Vehicle) // Include related VehicleEntity
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(vu => new VehicleUsageDto
                {
                    Id = vu.Id,
                    VehicleId = vu.VehicleId,
                    VehicleName = vu.Vehicle.Name,
                    VehiclePlate = vu.Vehicle.Plate,
                    VehicleImagePath = vu.Vehicle.ImagePath,
                    ActiveHours = vu.ActiveHours,
                    MaintenanceHours = vu.MaintenanceHours,
                    Week = vu.Week
                })
                .ToListAsync();

            var result = new VehicleUsageListDto
            {
                VehicleUsages = vehicleUsages,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return new ServiceMessage<VehicleUsageListDto>
            {
                IsSucceed = true,
                Data = result
            };
        }
        #endregion

        #region Get ById
        public async Task<ServiceMessage<VehicleUsageDto>> GetById(int id)
        {
            var vehicleUsageEntity = await _vehicleUsageRepository
                .GetAll()
                .Include(vu => vu.Vehicle) // Include related VehicleEntity
                .FirstOrDefaultAsync(vu => vu.Id == id);

            if (vehicleUsageEntity == null)
            {
                return new ServiceMessage<VehicleUsageDto>
                {
                    IsSucceed = false,
                    Message = "Vehicle usage not found.",
                    Data = null
                };
            }

            var vehicleUsageDto = new VehicleUsageDto
            {
                Id = vehicleUsageEntity.Id,
                VehicleId = vehicleUsageEntity.VehicleId,
                VehicleName = vehicleUsageEntity.Vehicle.Name,
                VehiclePlate = vehicleUsageEntity.Vehicle.Plate,
                VehicleImagePath = vehicleUsageEntity.Vehicle.ImagePath, // Fetch ImagePath dynamically
                ActiveHours = vehicleUsageEntity.ActiveHours,
                MaintenanceHours = vehicleUsageEntity.MaintenanceHours,
                Week = vehicleUsageEntity.Week
            };

            return new ServiceMessage<VehicleUsageDto>
            {
                IsSucceed = true,
                Data = vehicleUsageDto
            };
        }
        #endregion

        #region Update
        public async Task<ServiceMessage> UpdateVehicleUsage(EditVehicleUsageDto vehicleUsageDto)
        {
            var vehicleUsageEntity = _vehicleUsageRepository.GetById(vehicleUsageDto.Id);

            if (vehicleUsageEntity == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Vehicle usage record not found."
                };
            }

            vehicleUsageEntity.VehicleId = vehicleUsageDto.VehicleId;
            vehicleUsageEntity.ActiveHours = vehicleUsageDto.ActiveHours;
            vehicleUsageEntity.MaintenanceHours = vehicleUsageDto.MaintenanceHours;
            vehicleUsageEntity.Week = vehicleUsageDto.Week;

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Vehicle usage record updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = $"Error while updating vehicle usage: {ex.Message}"
                };
            }
        }
        #endregion

        #region Delete
        public async Task<ServiceMessage> DeleteVehicleUsage(int id)
        {
            var vehicleUsageEntity = _vehicleUsageRepository.GetById(id);

            if (vehicleUsageEntity == null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Vehicle usage record not found."
                };
            }

            _vehicleUsageRepository.DeleteById(vehicleUsageEntity.Id);

            try
            {
                await _unitOfWork.SaveChangesAsync();
                return new ServiceMessage
                {
                    IsSucceed = true,
                    Message = "Vehicle usage record deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = $"Error while deleting vehicle usage: {ex.Message}"
                };
            }
        }
        #endregion

        #region GetAll Vehice Usages
        public async Task<ServiceMessage<List<VehicleUsageDto>>> GetAll()
        {
            var vehicleUsages = await _vehicleUsageRepository
                .GetAll()
                .Include(vu => vu.Vehicle) // Include related VehicleEntity
                .Select(vu => new VehicleUsageDto
                {
                    Id = vu.Id,
                    VehicleId = vu.VehicleId,
                    VehicleName = vu.Vehicle.Name,
                    VehiclePlate = vu.Vehicle.Plate,
                    VehicleImagePath = vu.Vehicle.ImagePath, // Fetch ImagePath dynamically
                    ActiveHours = vu.ActiveHours,
                    MaintenanceHours = vu.MaintenanceHours,
                    Week = vu.Week
                })
                .ToListAsync();

            if (vehicleUsages == null)
            {
                return new ServiceMessage<List<VehicleUsageDto>>
                {
                    IsSucceed = false,
                    Message = "There is no vehicle usage...",
                    Data = null
                };
            }
            return new ServiceMessage<List<VehicleUsageDto>>
            {
                IsSucceed = true,
                Message = "Vehicle Usage Listed Succesfully ...",
                Data = vehicleUsages
            };
        }
        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Business.Operations.VehicleUsage.Dtos;
using VehicleEfficiencyAcd.Business.Types;

namespace VehicleEfficiencyAcd.Business.Operations.VehicleUsage
{
    public interface IVehicleUsageService // -> Service interface for I will use Vehicle Usage operations
    {
        Task<ServiceMessage> AddVehicleUsage(AddVehicleUsageDto vehicleUsageDto);
        Task<ServiceMessage<VehicleUsageListDto>> GetAllWithPages(int page, int pageSize);
        Task<ServiceMessage<VehicleUsageDto>> GetById(int id);
        Task<ServiceMessage> UpdateVehicleUsage(EditVehicleUsageDto vehicleUsageDto);
        Task<ServiceMessage> DeleteVehicleUsage(int id);
        Task<ServiceMessage<List<VehicleUsageDto>>> GetAll();
    }
}

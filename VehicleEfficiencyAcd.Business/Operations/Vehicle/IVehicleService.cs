using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Business.Operations.Vehicle.Dtos;
using VehicleEfficiencyAcd.Business.Operations.VehicleUsage.Dtos;
using VehicleEfficiencyAcd.Business.Types;

namespace VehicleEfficiencyAcd.Business.Operations.Vehicle
{
    public interface IVehicleService // -> Service interface for I will use Vehicle operations
    {
        Task<ServiceMessage<VehicleListDto>> GetAllWithPages(int page, int pageSize);
        Task<ServiceMessage> AddVehicle(AddVehicleDto dto);
        Task<ServiceMessage> DeleteVehicle(int id);
        Task<ServiceMessage<List<VehicleDto>>> GetAll();
        Task<ServiceMessage<EditVehicleDto>> GetById(int id);
        Task<ServiceMessage> UpdateVehicle(EditVehicleDto vehicleDto);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Business.Operations.VehicleUsage.Dtos
{
    public class VehicleUsageDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleImagePath { get; set; }
        public double ActiveHours { get; set; }
        public double MaintenanceHours { get; set; }
        public string Week { get; set; }
    }
}

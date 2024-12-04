using System.Reflection.Metadata.Ecma335;

namespace VehicleEfficiencyAcd.Presentation.Models.VehicleUsage
{
    public class VehicleUsageViewModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleImagePath { get; set; }
        public double ActiveHours { get; set; }
        public double MaintenanceHours { get; set; }
        public string Week { get; set; }
        public double TotalHours { get; set; } 
        public double WorkHours { get; set; }  
        public double IdleHours { get; set; }

    }
}

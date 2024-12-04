using Microsoft.AspNetCore.Mvc.Rendering;

namespace VehicleEfficiencyAcd.Presentation.Models.VehicleUsage
{
    public class AddVehicleUsageViewModel
    {
        public int VehicleId { get; set; }
        public string Week { get; set; }
        public double ActiveHours { get; set; }
        public double MaintenanceHours { get; set; }
        public List<SelectListItem> Vehicles { get; set; }

    }
}

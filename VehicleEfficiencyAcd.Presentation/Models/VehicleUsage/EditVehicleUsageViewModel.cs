using Microsoft.AspNetCore.Mvc.Rendering;

namespace VehicleEfficiencyAcd.Presentation.Models.VehicleUsage
{
    public class EditVehicleUsageViewModel
    {
        public int Id { get; set; } 
        public int VehicleId { get; set; } 
        public double ActiveHours { get; set; } 
        public double MaintenanceHours { get; set; } 
        public string Week { get; set; } 

        // A list of vehicles to be displayed in a dropdown menu
        public List<SelectListItem> Vehicles { get; set; }
    }
}

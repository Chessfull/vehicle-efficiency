using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VehicleEfficiencyAcd.Presentation.Models.VehicleUsage
{
    public class AddVehicleUsageRequest
    {
        public int VehicleId { get; set; }
        [RegularExpression(@"^W[1-9][0-9]*$", ErrorMessage = "Week must be in the format W1, W2, W3, etc.")]
        public string Week { get; set; }
        [Range(0, 168, ErrorMessage = "Active hours must be between 0 and 168.")]
        public double ActiveHours { get; set; }
        [Range(0, 168, ErrorMessage = "Maintenance hours must be between 0 and 168.")]
        public double MaintenanceHours { get; set; }
    }
}

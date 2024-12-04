using System.ComponentModel.DataAnnotations;

namespace VehicleEfficiencyAcd.Presentation.Models.Vehicle
{
    public class EditRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is necessary field.")]
        [StringLength(30, ErrorMessage = "Vehicle name length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is necessary field.")]
        [StringLength(10, ErrorMessage = "Vehicle plate length must be between {2} and {1}.", MinimumLength = 6)]
        public string Plate { get; set; }

        public string? ImagePath { get; set; } // To display the current image
    }
}

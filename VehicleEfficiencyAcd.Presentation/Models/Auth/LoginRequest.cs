using System.ComponentModel.DataAnnotations;

namespace VehicleEfficiencyAcd.Presentation.Models.Auth
{
    public class LoginRequest // -> Request model for login processes
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

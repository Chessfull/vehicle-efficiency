using System.ComponentModel.DataAnnotations;

namespace VehicleEfficiencyAcd.Presentation.Models.Auth
{
    public class RegisterRequest // -> I created this for register request processes from user with model validations below
    {
        [Required(ErrorMessage = "{0} is necessary field.")]
        [EmailAddress]
        [StringLength(80, ErrorMessage = "Email length must be between {2} and {1}.", MinimumLength = 8)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "{0} is necessary field.")]
        [StringLength(30, ErrorMessage = "Password length must be between {2} and {1}.", MinimumLength = 8)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "{0} is necessary field.")]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "{0} is necessary field.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is necessary field.")]
        public string LastName { get; set; }
    }
}

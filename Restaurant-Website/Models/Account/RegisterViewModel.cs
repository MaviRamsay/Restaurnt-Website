using System.ComponentModel.DataAnnotations;

namespace Restaurant_Website.Models.Account
{
    public class RegisterViewModel
    {
        [Phone(ErrorMessage = "Enter a valid phone number")]
        [Required(ErrorMessage = "Fill this field")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fill this field")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords doesn't match")]
        [Required(ErrorMessage = "Fill this field")]
        public string ConfirmPassword { get; set; }
    }
}

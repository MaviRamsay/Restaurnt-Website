using System.ComponentModel.DataAnnotations;

namespace Restaurant_Website.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Fill this field")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Fill this field")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}

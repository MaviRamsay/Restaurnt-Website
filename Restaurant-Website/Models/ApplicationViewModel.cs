using System;
using System.ComponentModel.DataAnnotations;
using Resources.ValidateResources.Home.Work;
using Microsoft.AspNetCore.Http;

namespace Restaurant_Website.Models
{
    public class ApplicationViewModel
    {
        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        [StringLength(20, MinimumLength = 3, ErrorMessageResourceName = nameof(ValidateStrings.StringLength), ErrorMessageResourceType = typeof(ValidateStrings))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        [StringLength(20, MinimumLength = 3, ErrorMessageResourceName = nameof(ValidateStrings.StringLength), ErrorMessageResourceType = typeof(ValidateStrings))]
        public string Surname { get; set; }

        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        [EmailAddress(ErrorMessageResourceName = nameof(ValidateStrings.Email), ErrorMessageResourceType = typeof(ValidateStrings))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        [Range(14, 65, ErrorMessageResourceName = nameof(ValidateStrings.Age), ErrorMessageResourceType = typeof(ValidateStrings))]
        public int Age { get; set; }

        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        public int Vacancy { get; set; }

        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        public IFormFile Cv { get; set; }
    }
}

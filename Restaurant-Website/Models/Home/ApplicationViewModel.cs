using System;
using System.ComponentModel.DataAnnotations;
using Resources.ValidateResources.Home.Work;
using Microsoft.AspNetCore.Http;

namespace Restaurant_Website.Models.Home
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
        [Range(0, 100, ErrorMessageResourceName = nameof(ValidateStrings.Age), ErrorMessageResourceType = typeof(ValidateStrings))]
        public int Age { get; set; }

        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        public int Vacancy { get; set; }

        [Required(ErrorMessageResourceName = nameof(ValidateStrings.Required), ErrorMessageResourceType = typeof(ValidateStrings))]
        //[FileExtensions(Extensions = "doc,docx,pdf", ErrorMessageResourceName = nameof(ValidateStrings.FileExtension), ErrorMessageResourceType = typeof(ValidateStrings))]
        public IFormFile Cv { get; set; }
    }
}

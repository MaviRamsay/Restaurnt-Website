using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Website.Domain.Core
{
    public class ApplicationDTO
    {
        [Remote("", "")]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Vacancy { get; set; }
        [Required]
        //[FileExtensions(Extensions = "doc,docx,pdf")]
        public IFormFile Cv { get; set; }
    }
}

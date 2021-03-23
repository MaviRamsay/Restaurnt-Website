using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Website.Domain.Core
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public DateTime SubmitDate { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public int? VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public int? CvId { get; set; }
        public UploadedFile Cv { get; set; }
    }
}

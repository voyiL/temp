using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Primary_HealthCare_System.Models
{
    public class PatientEducation
    {
        [Key]
        public int Id { get; set; }



        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }
    }
}

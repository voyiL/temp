using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Primary_HealthCare_System.Models
{
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; }

        [Required]
        [Display(Name = "Visit Date")]
        public DateTime VisitDate { get; set; }

        public string Diagnosis { get; set; }

        public string Prescription { get; set; }

        [Display(Name = "Doctor's Notes")]
        public string DoctorsNotes { get; set; }
    }
}

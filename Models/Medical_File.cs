using Asp.NetProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primary_HealthCare_System.Models
{
    public class Medical_File
    {
        [Key]
        public int FileId { get; set; }
        [Required]
        [Display(Name = "Patient")]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]

        public ApplicationUser? PatinetUser { get; set; }
        [Required]
        [Display(Name = "ID Number")]
        [MaxLength(13)]
        [MinLength(13)]
        public string? IDNumber { get; set; }


        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
        [Required]

        [Display(Name ="Gender")]
        public string? Gender { get; set; }
        [Required]
        [Display(Name ="Address")]
        public string? Address { get; set; }

        ///Medical Section
        [Display(Name ="Blood Type")]
        public string? BloodType { get; set; }

        [Display(Name = "Allergies")]

        public string? Allergies { get; set; }

        [Required]
        [Display(Name = "Emergency Person Full Name")]
        public string? EmergencyPerson { get; set; }

        [Required]
        [Display(Name = "Emergency Person Contact")]
        public string? EmergencyPersonConact { get; set; }

    }
}

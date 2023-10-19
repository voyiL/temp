using Asp.NetProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primary_HealthCare_System.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Created Date")]
        public DateTime AppointmentCreatedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Appointment Time")]
        public DateTime AppointmentTime { get; set; }
        [Required]
        [Display(Name = "Purpose")]
        public string? Purpose { get; set; }
        [Required]
        [Display(Name = "Doctor/Nurse/Counsellor")]
        public string? clinician { get; set; }
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual ApplicationUser MAinUSer { get; set; }
        public string? Status { get; set; }
        public Appointments()
        {
            AppointmentCreatedDate = DateTime.Now;
            Status = "Pending";
        }
    }
}

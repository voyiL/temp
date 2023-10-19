using Asp.NetProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Primary_HealthCare_System.Models
{
    public class Reminder
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Patient name is required.")]
        [StringLength(50, ErrorMessage = "Patient name must be between 1 and 50 characters.", MinimumLength = 1)]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Medication name is required.")]
        [StringLength(100, ErrorMessage = "Medication name must be between 1 and 100 characters.", MinimumLength = 1)]
        public string MedicationName { get; set; }

        [Required(ErrorMessage = "Reminder message is required.")]
        [StringLength(200, ErrorMessage = "Reminder message must be between 1 and 200 characters.", MinimumLength = 1)]
        public string ReminderMessage { get; set; }

        [Required(ErrorMessage = "Reminder time is required.")]
        [RegularExpression(@"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Invalid time format. Use HH:mm format.")]
        public string ReminderTime { get; set; }

        // Convert ReminderTime string to DateTime
        public DateTime GetReminderDateTime()
        {
            return DateTime.ParseExact(ReminderTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        }
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual ApplicationUser MAinUSer { get; set; }
    }
}

using Asp.NetProject.Areas.Identity.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Primary_HealthCare_System.Models
{
    public class RefillRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "IDnumber")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ID number must be 13 digits.")]
        public string? IDnumber { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Medication Name")]
        public string   Medication { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]

        [DataType(DataType.Date)]
        //[FutureDate(ErrorMessage = "Please select a future date.")]
        public DateTime Date { get; set; }

        public bool IsApproved { get; set; }

       
    }
}

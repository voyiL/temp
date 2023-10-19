using System.ComponentModel.DataAnnotations;

namespace Primary_HealthCare_System.Models
{
	public class Referal
	{
		[Key]
		public int ReferralID { get; set; }

		[Display(Name = "Counseling Session Date")]
		[Required(ErrorMessage = "Please provide the counseling session date.")]
		[DataType(DataType.Date)]
		public DateTime CounselingSessionDate { get; set; }
		[Display(Name = "Patient")]
		[Required(ErrorMessage = "Please select the patient.")]
		public string PatientID { get; set; }

		[Display(Name = "Referral Date")]
		[Required(ErrorMessage = "Please provide the referral date.")]
		public DateTime ReferralDate { get; set; }

		[Display(Name = "Referring Doctor")]
		[Required(ErrorMessage = "Please select the referring doctor.")]
		public string ReferringDoctorID { get; set; }


		[Display(Name = "Referral Reason")]
		[Required(ErrorMessage = "Please provide the reason for referral.")]
		public string ReferralReason { get; set; }

		[Display(Name = "Additional Notes")]
		public string AdditionalNotes { get; set; }
	}
}

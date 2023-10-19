using System.ComponentModel.DataAnnotations;

namespace Primary_HealthCare_System.Models
{
	public class Medical_Record
	{
		[Key]
		public int RecordID { get; set; }

		

		[Display(Name = "Counselor")]
		[Required(ErrorMessage = "Please select a counselor.")]
		public string? CounselorID { get; set; }
		[DataType(DataType.Date)]
		[Display(Name = "Session Date")]
		[Required(ErrorMessage = "Please enter the session date.")]
		public DateTime SessionDate { get; set; }

		[Display(Name = "Session Notes")]
		[Required(ErrorMessage = "Please provide session notes.")]
		public string? SessionNotes { get; set; }

		[Display(Name = "Issues Discussed")]
		public string? IssuesDiscussed { get; set; }

		[Display(Name = "Homework Assigned")]
		public string? HomeworkAssigned { get; set; }

		[Display(Name = "Progress")]
		public string? Progress { get; set; }

		[Display(Name = "Follow-up Plans")]
		public string? FollowUpPlans { get; set; }

		[Display(Name = "Next Session Date")]
		public DateTime? NextSessionDate { get; set; }

		// Medical Information
		[Display(Name = "Patient")]
		[Required(ErrorMessage = "Please select a patient.")]
		public string? PatientID { get; set; }

	

		[Display(Name = "Medical Condition")]
		[Required(ErrorMessage = "Please provide the medical condition.")]
		public string MedicalCondition { get; set; }

		[Display(Name = "Diagnosis")]
		public string Diagnosis { get; set; }

		[Display(Name = "Treatment Plan")]
		public string TreatmentPlan { get; set; }

		[Display(Name = "Medications")]
		public string Medications { get; set; }

		[Display(Name = "Lab Results")]
		public string LabResults { get; set; }
		[Display(Name = "Procedures")]
		public string Procedures { get; set; }

		[Display(Name = "Follow-up Instructions")]
		public string FollowUpInstructions { get; set; }

		[Display(Name = "Notes")]
		public string Notes { get; set; }
	}
}

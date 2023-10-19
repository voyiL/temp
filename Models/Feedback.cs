using System.ComponentModel.DataAnnotations;

namespace Primary_HealthCare_System.Models
{
	public class Feedback
	{
		[Key]
		public int FeedbackID { get; set; }

		[Display(Name = "Session Date")]
		[Required(ErrorMessage = "Please provide the session date.")]
		public DateTime SessionDate { get; set; }

		[Display(Name = "Counselor")]
		[Required(ErrorMessage = "Please select the counselor.")]
		public string CounselorID { get; set; }

		[Display(Name = "Client")]
		[Required(ErrorMessage = "Please select the client.")]
		public int ClientID { get; set; }

		[Display(Name = "Overall Rating")]
		[Required(ErrorMessage = "Please provide an overall rating.")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
		public int OverallRating { get; set; }

		[Display(Name = "Communication")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
		public int CommunicationRating { get; set; }

		[Display(Name = "Effectiveness")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
		public int EffectivenessRating { get; set; }

		[Display(Name = "Comfort")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
		public int ComfortRating { get; set; }

		[Display(Name = "Comments")]
		public string Comments { get; set; }
	}
}

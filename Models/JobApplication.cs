using System.ComponentModel.DataAnnotations;

namespace JobSearchAppBackend.Models
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationId { get; set; }

        [Required(ErrorMessage = "Applicant Name is required.")]
        [StringLength(100, ErrorMessage = "Applicant Name cannot exceed 100 characters.")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "Applicant Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string ApplicantEmail { get; set; }

        [Required(ErrorMessage = "Applicant Phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string ApplicantPhone { get; set; }

        [Required(ErrorMessage = "Resume URL is required.")]
        //[Url(ErrorMessage = "Invalid URL.")]
        public string ResumeUrl { get; set; }

        [Required(ErrorMessage = "Cover Letter is required.")]
        public string CoverLetter { get; set; }

        [Required(ErrorMessage = "Application Date is required.")]
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;

        // Foreign key for JobListing
        public int JobListingId { get; set; }

        // Navigation property for JobListing
        public JobListing JobListing { get; set; }
    }
}

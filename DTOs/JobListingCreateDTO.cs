using System.ComponentModel.DataAnnotations;

namespace JobSearchAppBackend.DTOs
{
    public class JobListingCreateDTO
    {
        public int JobId { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Job description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        public DateTime PostedDate { get; set; } = DateTime.Now;

        public int CompanyId { get; set; }
    }
}

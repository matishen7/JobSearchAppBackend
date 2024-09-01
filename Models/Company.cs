using System.ComponentModel.DataAnnotations;

namespace JobSearchAppBackend.Models
{
    public class Company
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Company Name is required.")]
        [StringLength(100, ErrorMessage = "Company Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Company Location is required.")]
        public string Location { get; set; }
        public string Website { get; set; } 
        public string Industry { get; set; }

        // Navigation Property: A company can have multiple job listings
        public ICollection<Job> Jobs { get; set; }
    }
}

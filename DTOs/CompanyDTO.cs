using System.ComponentModel.DataAnnotations;

namespace JobSearchAppBackend.ViewModels
{
    public class CompanyDTO
    {
        [Required(ErrorMessage = "Company Name is required.")]
        [StringLength(100, ErrorMessage = "Company Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Company Location is required.")]
        public string Location { get; set; }
        public string Website { get; set; }
        public string Industry { get; set; }
    }
}

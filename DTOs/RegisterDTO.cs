using System.ComponentModel.DataAnnotations;

namespace JobSearchAppBackend.DTOs
{
    public class RegisterDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }  
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [RegularExpression("^(JobSeeker|Employer)$", ErrorMessage = "Invalid role selection.")]
        public string Role { get; set; } 
    }

}

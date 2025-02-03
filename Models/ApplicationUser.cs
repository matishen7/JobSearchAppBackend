using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

namespace JobSearchAppBackend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}

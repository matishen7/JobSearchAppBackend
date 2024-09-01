using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobSearchAppBackend.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime PostedDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

namespace JobSearchAppBackend.Models
{
    public class Company
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the Company
        public string Description { get; set; } // Description of the Company
        public string Location { get; set; } // Company Location
        public string Website { get; set; } // Company's Website URL
        public string Industry { get; set; } // Industry the Company belongs to

        // Navigation Property: A company can have multiple job listings
        public ICollection<Job> Jobs { get; set; }
    }
}

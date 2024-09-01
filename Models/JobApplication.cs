namespace JobSearchAppBackend.Models
{
    public class JobApplication
    {
        public int Id { get; set; } // Primary Key
        public int JobId { get; set; } // Foreign Key for Job
        public int UserId { get; set; } // Foreign Key for User
        public string Resume { get; set; } // Path to the uploaded resume or resume text
        public string CoverLetter { get; set; } // Cover letter text
        public DateTime AppliedDate { get; set; } // Date of application submission

        // Navigation Properties
        public Job Job { get; set; } // Reference to the Job being applied for
        public User User { get; set; } // Reference to the User applying for the job
    }
}

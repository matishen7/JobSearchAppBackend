namespace JobSearchAppBackend.DTOs
{
    public class JobApplicationDto
    {
        public int Id { get; set; }

        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public string ApplicantPhone { get; set; }
        public string ResumeUrl { get; set; }
        public string CoverLetter { get; set; }
        public DateTime ApplicationDate { get; set; }

        // Foreign key for JobListing
        public int JobListingId { get; set; }

        // Optional: Include JobListing details if needed
        //public JobListingDTO JobListing { get; set; }
    }
}

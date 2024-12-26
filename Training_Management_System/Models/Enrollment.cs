namespace Training_Management_System.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string EnrollmentStatus { get; set; }

        public DateTime RequestDate { get; set; }

        //Adding the foreign keys from User and Batch

        public int UserId { get; set; }
        public User? User { get; set; }

        public int BatchId { get; set; }

        public Batch? Batch { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; } // is to perform soft delete

        public List<Feedback> Feedbacks { get; set; }
    }
}

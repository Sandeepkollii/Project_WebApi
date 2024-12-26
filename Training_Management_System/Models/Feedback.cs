namespace Training_Management_System.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string? Text { get; set; }
        public DateTime? Date { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; } // is to perform soft delete

        //Foreign key
        public int EnrollmentId { get; set; }
        public Enrollment? Enrollment { get; set; }
    }
}

namespace TMS_Application.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int BatchCount { get; set; }

        //Adding the foreign key
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; } // is to perform soft delete

        public List<Enrollment>? Enrollments { get; set; }
    }
}

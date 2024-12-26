namespace Training_Management_System.Models
{
    public class Course
    {
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int Duration { get; set; }
        public bool Availability { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsActive { get; set; } // is to perform soft delete

        public List<Batch>? Batches { get; set; }
    }
}

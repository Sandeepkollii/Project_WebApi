using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Repo
{
    public class CourseRepository : ICourseRepository
    {
        AppDbContext _dbContext;
        public CourseRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public Course AddCourse(Course course)
        {
            course.IsActive = true;
            _dbContext.Course.Add(course);
            _dbContext.SaveChanges();
            return course;
        }

        public bool DeleteCourse(int CourseId)
        {
            Course course = GetCourseById(CourseId);
            if (course != null)
            {
                course.IsActive = false;
                //_dbContext.Remove(course);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public Course GetCourseById(int id)
        {
            var course = _dbContext.Course.FirstOrDefault(x => x.CourseId == id && x.IsActive==true);
            return course;
        }

        public string GetCourseName(string courseName)
        {
            string course = _dbContext.Course.FirstOrDefault(x => x.CourseName == courseName && x.IsActive == true).ToString();
            return course;
        }

        public List<Course> GetCourses()
        {
            return _dbContext.Course.Where(x=>x.IsActive==true).ToList();
        }

        public bool UpdateCourse(int CourseId, Course course)
        {
            Course obj = GetCourseById(CourseId);
            if (obj != null)
            {
                obj.CourseName = course.CourseName;
                obj.Duration = course.Duration;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        
    }
}

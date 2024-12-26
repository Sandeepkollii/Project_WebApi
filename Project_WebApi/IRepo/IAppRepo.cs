using Project_WebApi.Models;
using Project_WebApi.ViewModels;

namespace Project_WebApi.IRepo
{
    public interface IBatchRepository
    {
        List<Batch> GetBatches();
        
        Batch GetBatchById(int id);
        Batch AddBatch(Batch batch);
        bool UpdateBatch(int id,Batch batch);
        bool DeleteBatch(int id);
        


    }
    public interface ICourseRepository
    {
        List<Course> GetCourses();
        Course GetCourseById(int id);
        Course AddCourse(Course course);
        bool UpdateCourse(int id,Course course);
        bool DeleteCourse(int id);

        string GetCourseName(string courseName);

    }
    public interface IUserRepository
    {
        List <User> GetUsers();
        User GetUserById(int id);
        User AddUser(User user);
        bool UpdateUser(int id,User user);
        bool DeleteUser(int id);

    }
    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrollments();
        Enrollment GetEnrollmentsById(int id);
        Enrollment AddEnrollments(Enrollment enrollment);
        bool UpdateEnrollments(int id,Enrollment enrollment);


    }
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Role GetRoleById(int id);
        Role AddRole(Role role);
        bool UpdateRole(int id,Role role);
        bool DeleteRole(Role role);

    }
    public interface IFeedbackRepository
    {
        List<Feedback> GetFeedbacks();
        Feedback GetFeedbackById(int id);
        Feedback AddFeedback(Feedback feedback);
        bool UpdateFeedback(int id,Feedback feedback);
        bool DeleteFeedback(int id);

    }
    public interface IAuthenticateRepository
    {
        User AuthenticateUser(LoginViewModel loginViewModel);
    }

}

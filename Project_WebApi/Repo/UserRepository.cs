using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Repo
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _dbContext;
        public UserRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public User AddUser(User user)
        {
            user.IsActive = true;
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
        public User UpdateUser(User user)
        {
            _dbContext.Update(user);
            return user;

        }
        public bool DeleteUser(int UserId)
        {
            User user = GetUserById(UserId);
            if (user != null)
            {
                user.IsActive &= false;
                //_dbContext.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserId == id && x.IsActive==true);
            return user;
        }
        public List<User> GetUsers()
        {
            return _dbContext.Users.Where(x=>x.IsActive==true).ToList();
        }

        public bool UpdateUser(int UserId, User user)
        {
            User obj = GetUserById(UserId);
            if (obj != null)
            {
                obj.UserName = user.UserName;
                obj.Role = user.Role;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
}
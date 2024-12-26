using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;
using Project_WebApi.ViewModels;

namespace Project_WebApi.Repo
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        AppDbContext _dbContext;
        public AuthenticateRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public User AuthenticateUser(LoginViewModel loginViewModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == loginViewModel.UserName
             && x.Password == loginViewModel.Password);
            return user;

        }
    }
}

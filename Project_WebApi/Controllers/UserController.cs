using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_userRepo.GetUsers());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUsersById(int id)
        {
            return Ok(_userRepo.GetUserById(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post(User usr)
        {
            _userRepo.AddUser(usr);
            return Created("User created", usr);
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User usr)
        {
            _userRepo.UpdateUser(id, usr);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepo.DeleteUser(id);
            return Ok();
        }


    }
}

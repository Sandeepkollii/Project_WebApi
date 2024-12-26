using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        IEnrollmentRepository _enrollmentRepo;
        public EnrollmentController(IEnrollmentRepository enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_enrollmentRepo.GetEnrollments());
        }

        // GET api/<BatchController>/5
        [HttpGet("{id}")]
        public IActionResult GetEnrollmentsById(int id)
        {
            return Ok(_enrollmentRepo.GetEnrollmentsById(id));
        }

        // POST api/<BatchController>
        [HttpPost]
        public IActionResult Post(Enrollment enrollment)
        {
            _enrollmentRepo.AddEnrollments(enrollment);
            return Created("Enrollment added", enrollment);
        }
        // PUT api/<BatchController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Enrollment enrollment)
        {
            _enrollmentRepo.UpdateEnrollments(id, enrollment);
            return Ok();
        }

       

    }
}

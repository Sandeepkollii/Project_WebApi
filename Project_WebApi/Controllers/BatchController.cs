using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        IBatchRepository _batchRepo;
        public BatchController(IBatchRepository batchRepo)
        {
            _batchRepo = batchRepo;
        } 

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_batchRepo.GetBatches());
        }

        // GET api/<BatchController>/5
        [HttpGet("{id}")]
        public IActionResult GetbatchesById(int id)
        {
            return Ok(_batchRepo.GetBatchById(id));
        }

        // POST api/<BatchController>
        [HttpPost]
        public IActionResult Post(Batch batch)
        {
            _batchRepo.AddBatch(batch);
            return Created("Batch Created", batch);
        }
        // PUT api/<BatchController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Batch batch)
        {
            _batchRepo.UpdateBatch(id, batch);
            return Ok();
        }

        // DELETE api/<BatchController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _batchRepo.DeleteBatch(id);
            return Ok();
        }

    }
}

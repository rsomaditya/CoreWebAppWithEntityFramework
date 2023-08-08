using CoreWebAppWithEF.Models;
using CoreWebAppWithEF.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebAppWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateMicroserviceController : ControllerBase
    {
        private InterfaceCandidateRepo _interfaceCandidateRepo;

        public CandidateMicroserviceController(InterfaceCandidateRepo icr)
        {
            _interfaceCandidateRepo = icr;
        }

        // GET: api/<CandidateMicroserviceController>
        [HttpGet]
        public IActionResult Get()
        {
            var ob = _interfaceCandidateRepo.get();
            return new OkObjectResult(ob);
        }

        // GET api/<CandidateMicroserviceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ob = _interfaceCandidateRepo.get(id);
            return new OkObjectResult(ob);
        }

        // POST api/<CandidateMicroserviceController>
        [HttpPost]
        public IActionResult Post([FromBody] Candidate candidate)
        {
            using (var scope = new TransactionScope())
            {
                _interfaceCandidateRepo.post(candidate);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = candidate.metaid }, candidate);
            }

        }

        // PUT api/<CandidateMicroserviceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Candidate candidate)
        {
            if (candidate != null)
            {
                using (var scope = new TransactionScope())
                {
                    _interfaceCandidateRepo.put(candidate);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<CandidateMicroserviceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _interfaceCandidateRepo.delete(id);
            return new OkResult();
        }
    }
}

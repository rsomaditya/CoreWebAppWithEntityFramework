using CoreWebAppWithEF.Context;
using CoreWebAppWithEF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebAppWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private LmsContext _lmscontext;
        public CandidateController(LmsContext lmsContext)
        {
            _lmscontext = lmsContext;
        }

        // GET: api/<CandidateController>
        [HttpGet]
        public IEnumerable<Candidate> Get()
        {
            if (_lmscontext.Candidates != null)
                return _lmscontext.Candidates;
            else
            {
                return new List<Candidate> { new Candidate() };
            }
                
        }

        // GET api/<CandidateController>/5
        [HttpGet("{id}")]
        public Candidate Get(int id)
        {
            return _lmscontext.Candidates.FirstOrDefault(s => s.metaid == id);
        }

        // POST api/<CandidateController>
        [HttpPost]
        public void Post([FromBody] Candidate value)
        {
            _lmscontext.Candidates.Add(value);
            _lmscontext.SaveChanges();
        }

        // PUT api/<CandidateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Candidate value)
        {
            var ob = _lmscontext.Candidates.FirstOrDefault(s => s.metaid == id);
            if (ob != null)
            {
                _lmscontext.Entry<Candidate>(ob).CurrentValues.SetValues(value);
                _lmscontext.SaveChanges();
            }
        }

        // DELETE api/<CandidateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _lmscontext.Candidates.FirstOrDefault(s => s.metaid == id);
            if (student != null)
            {
                _lmscontext.Candidates.Remove(student);
                _lmscontext.SaveChanges();
            }
        }
    }
}

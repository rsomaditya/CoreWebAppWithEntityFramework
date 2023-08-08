using Microsoft.EntityFrameworkCore;
using CoreWebAppWithEF.Context;
using CoreWebAppWithEF.Models;

namespace CoreWebAppWithEF.Repository
{
    public class CandidateRepo: InterfaceCandidateRepo
    {
        private readonly LmsContext _dbContext;
        public CandidateRepo(LmsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Candidate> get()
        {
            return _dbContext.Candidates.ToList();
        }
        public Candidate get(int id)
        {
            return _dbContext.Candidates.Find(id);
        }
        public void post(Candidate candidate)
        {
            _dbContext.Add(candidate);
            save();
        } 
        public void put(Candidate candidate)
        {
            _dbContext.Entry(candidate).State = EntityState.Modified;
            save();
        }
        public void delete(int id)
        {
            var ob = _dbContext.Candidates.Find(id);
            _dbContext.Candidates.Remove(ob);
            save();
        }
        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}

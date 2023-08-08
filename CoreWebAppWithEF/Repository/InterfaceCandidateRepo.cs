using CoreWebAppWithEF.Models;

namespace CoreWebAppWithEF.Repository
{
    public interface InterfaceCandidateRepo
    {
        IEnumerable<Candidate> get();
        Candidate get(int id);
        void post(Candidate candidate);
        void put(Candidate candidate);
        void delete(int id);
        void save();
    }
}

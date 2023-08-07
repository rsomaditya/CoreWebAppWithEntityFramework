using CoreWebAppWithEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAppWithEF.Context
{
    public class LmsContext:DbContext
    {
        public LmsContext(DbContextOptions<LmsContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
    }
}

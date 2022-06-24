using Microsoft.EntityFrameworkCore;

namespace Agents.Model
{
    public class AgentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyRegistrationRequest> CompanyRegistrationRequests { get; set; }

        public AgentDbContext(DbContextOptions<AgentDbContext> options) : base(options)
        {
        }

        protected AgentDbContext()
        {
        }
    }
}

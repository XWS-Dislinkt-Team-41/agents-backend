using Agents.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Agents.Model
{
    public class AgentDbContext
        : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AgentDbContext(DbContextOptions<AgentDbContext> options) : base(options)
        {
        }

        protected AgentDbContext()
        {
        }
    }
}

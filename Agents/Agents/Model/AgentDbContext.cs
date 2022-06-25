using Microsoft.EntityFrameworkCore;

namespace Agents.Model
{
    public class AgentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyRegistrationRequest> CompanyRegistrationRequests { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }

        public AgentDbContext(DbContextOptions<AgentDbContext> options) : base(options)
        {
        }

        protected AgentDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>(s =>
            {
                s.HasData(
                    new Skill("C#") { Id = 1 },
                    new Skill("C") { Id = 2 },
                    new Skill("C++") { Id = 3 },
                    new Skill("Java") { Id = 4 },
                    new Skill(".NET") { Id = 5 },
                    new Skill("SQL") { Id = 6 },
                    new Skill("Python") { Id = 7 },
                    new Skill("Go") { Id = 8 }
                );
            });
        }
    }
}

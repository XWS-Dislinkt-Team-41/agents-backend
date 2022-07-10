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


            modelBuilder.Entity<User>(user =>
            {
                user.HasData(
                    new User
                    {
                        Id = 1, FirstName = "Aleksa", LastName = "Papovic", Username = "pape",
                        Password = BCrypt.Net.BCrypt.HashPassword("123"), Role = Role.User
                    },
                    new User
                    {
                        Id = 2, FirstName = "Darko", LastName = "Vrbaski", Username = "dare",
                        Password = BCrypt.Net.BCrypt.HashPassword("123"), Role = Role.Admin
                    });
            });

            modelBuilder.Entity<User>().Property(e => e.Id).HasIdentityOptions(startValue: 3);


            modelBuilder.Entity<Company>(c =>
            {
                c.HasData(
                    new Company
                    {
                        Id = 1,
                        Name= "Arkansas",
                        Image= "https://upload.wikimedia.org/wikipedia/commons/9/9d/Flag_of_Arkansas.svg",
                    },
                    new Company
                    {
                        Id = 2,
                        Name = "Florida",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Florida.svg",
                    }, 
                    new Company
                    {
                        Id = 3,
                        Name = "Texas",
                        Image = "https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Texas.svg",
                    });
            });

            modelBuilder.Entity<User>().Property(e => e.Id).HasIdentityOptions(startValue: 3);


            modelBuilder.Entity<Skill>(s =>
                {
                    s.HasData(
                        new Skill("C#") {Id = 1},
                        new Skill("C") {Id = 2},
                        new Skill("C++") {Id = 3},
                        new Skill("Java") {Id = 4},
                        new Skill(".NET") {Id = 5},
                        new Skill("SQL") {Id = 6},
                        new Skill("Python") {Id = 7},
                        new Skill("Go") {Id = 8}
                    );
                });
            }
        }
    }


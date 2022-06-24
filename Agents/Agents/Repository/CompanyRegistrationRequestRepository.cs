using Agents.Model;

namespace Agents.Repository
{
    public class CompanyRegistrationRequestRepository : GenericRepository<CompanyRegistrationRequest>, ICompanyRegistrationRequestRepository
    {
        private readonly AgentDbContext _dbContext;

        public CompanyRegistrationRequestRepository(AgentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

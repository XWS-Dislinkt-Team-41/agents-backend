using System.Collections.Generic;
using System.Linq;
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

        public List<CompanyRegistrationRequest> GetAllUnansweredRequests()
        {
            return _dbContext.CompanyRegistrationRequests.Where(r => r.Status == RequestStatus.Waiting).ToList();
        }
    }
}

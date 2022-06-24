using System.Collections.Generic;
using Agents.Model;
using Agents.Repository;

namespace Agents.Repository
{
    public interface ICompanyRegistrationRequestRepository : IGenericRepository<CompanyRegistrationRequest>
    {
        public List<CompanyRegistrationRequest> GetAllUnansweredRequests();
    }
}

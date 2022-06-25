using System.Collections.Generic;
using Agents.Model;

namespace Agents.Repository
{
    public interface ICompanyRegistrationRequestRepository : IGenericRepository<CompanyRegistrationRequest>
    {
        public List<CompanyRegistrationRequest> GetAllUnansweredRequests();
    }
}

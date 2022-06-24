using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;

namespace Agents.Service
{
    public interface ICompanyRegistrationRequestService
    {
        public List<CompanyRegistrationRequest> GetAllUnansweredRequests();
        public void Accept(CompanyRegistrationRequestDTO registrationRequestDTO);
        public void Decline(CompanyRegistrationRequestDTO registrationRequestDTO);
    }
}

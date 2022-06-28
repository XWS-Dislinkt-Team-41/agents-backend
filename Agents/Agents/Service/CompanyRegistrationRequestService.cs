using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;
using Agents.Repository;

namespace Agents.Service
{
    public class CompanyRegistrationRequestService : ICompanyRegistrationRequestService
    {
        private readonly ICompanyRegistrationRequestRepository _requestRepository;
        private readonly IUserRepository _userRepository;

        public CompanyRegistrationRequestService(ICompanyRegistrationRequestRepository requestRepository, IUserRepository userRepository)
        {
            _requestRepository = requestRepository;
            _userRepository = userRepository;
        }
        public CompanyRegistrationRequest Create(CompanyRegistrationRequestDTO requestDto)
        {
            CompanyRegistrationRequest companyRegistrationRequest = new CompanyRegistrationRequest(requestDto.UserId, requestDto.ContactInformation, requestDto.ActivityDescription);
            return _requestRepository.Insert(companyRegistrationRequest);
        }

        public List<CompanyRegistrationRequest> GetAllUnansweredRequests()
        {
            return _requestRepository.GetAllUnansweredRequests();
        }

        public void Accept(CompanyRegistrationRequestDTO registrationRequestDTO)
        {
            CompanyRegistrationRequest registrationRequest = _requestRepository.Get(registrationRequestDTO.Id);
            if (registrationRequest.Accept() == false) return;
            User user = _userRepository.Get(registrationRequest.UserId);
            user.Role = Role.Owner;
            _requestRepository.Update(registrationRequest);
            _userRepository.Update(user);
        }

        public void Decline(CompanyRegistrationRequestDTO registrationRequestDTO)
        {
            CompanyRegistrationRequest registrationRequest = _requestRepository.Get(registrationRequestDTO.Id);
            if (registrationRequest.Decline() == false) return;
            _requestRepository.Update(registrationRequest);
        }
    }
}

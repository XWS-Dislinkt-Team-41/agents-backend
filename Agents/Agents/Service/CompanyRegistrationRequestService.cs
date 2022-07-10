using System;
using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;
using Agents.Repository;

namespace Agents.Service
{
    public class CompanyRegistrationRequestService : ICompanyRegistrationRequestService
    {
        private readonly ICompanyRegistrationRequestRepository _requestRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public CompanyRegistrationRequestService(ICompanyRegistrationRequestRepository requestRepository, IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _requestRepository = requestRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }
        public CompanyRegistrationRequest Create(CompanyRegistrationRequestDTO requestDto)
        {
            CompanyRegistrationRequest companyRegistrationRequest = new CompanyRegistrationRequest(requestDto.UserId, requestDto.ContactInformation, requestDto.ActivityDescription,requestDto.Name);
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
            Company newCompany = new Company();
            newCompany.Name = registrationRequest.Name;
            newCompany.ActivityDescription = registrationRequestDTO.ActivityDescription;
            newCompany.ContactInformation = registrationRequestDTO.ContactInformation;
            newCompany.Image =
                "https://source.unsplash.com/random";
            _companyRepository.Insert(newCompany);
        }

        public void Decline(CompanyRegistrationRequestDTO registrationRequestDTO)
        {
            CompanyRegistrationRequest registrationRequest = _requestRepository.Get(registrationRequestDTO.Id);
            if (registrationRequest.Decline() == false) return;
            _requestRepository.Update(registrationRequest);
        }
    }
}

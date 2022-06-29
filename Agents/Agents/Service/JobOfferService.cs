using System.Collections.Generic;
using System.Security.Claims;
using Agents.DTO;
using Agents.Model;
using Agents.Repository;
using Agents.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Agents.Service
{
    public class JobOfferService : IJobOfferService
    {
        private const string DislinktApiUrl = "http://localhost:8000/jobOffer";
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;

        public JobOfferService(IJobOfferRepository jobOfferRepository, ISkillRepository skillRepository, IMapper mapper, IHttpContextAccessor contextAccessor, IUserRepository userRepository)
        {
            _jobOfferRepository = jobOfferRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public List<JobOffer> GetAllJobOffers()
        {
            return _jobOfferRepository.GetAll();
        }

        public JobOffer GetJobOffer(long id)
        {
            return _jobOfferRepository.Get(id);
        }

        public List<Skill> GetAllSkills()
        {
            return _skillRepository.GetAll();
        }

        public JobOffer PostNewJobOffer(JobOfferDTO jobOfferDTO)
        {
            JobOffer jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
            PublishNewJobOffer(jobOffer);
            return _jobOfferRepository.Insert(jobOffer);
        }

        private void PublishNewJobOffer(JobOffer jobOffer)
        {
            _ = ApiCall.PostAsync(DislinktApiUrl, "", jobOffer, GetCurrentUserApiToken());
        }

        public JobOffer UpdateJobOffer(JobOfferDTO jobOfferDTO)
        {
            JobOffer jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
            PublishJobOfferUpdate(jobOffer);
            return _jobOfferRepository.Update(jobOffer);
        }

        private void PublishJobOfferUpdate(JobOffer jobOffer)
        {
            _ = ApiCall.PutAsync(DislinktApiUrl, "", jobOffer, GetCurrentUserApiToken());
        }

        public void DeleteJobOffer(long id)
        {
            JobOffer jobOffer = _jobOfferRepository.Get(id);
            PublishJobOfferDelete(jobOffer);
            _jobOfferRepository.Delete(id);
        }

        private void PublishJobOfferDelete(JobOffer jobOffer)
        {
            _ = ApiCall.DeleteAsync<JobOffer>(DislinktApiUrl, jobOffer.Id.ToString(), GetCurrentUserApiToken());
        }

        private string GetCurrentUserApiToken()
        {
            string id = _contextAccessor.HttpContext.User.FindFirstValue("id");
            User user = _userRepository.Get(long.Parse(id));
            return user.ApiToken;
        }
    }
}

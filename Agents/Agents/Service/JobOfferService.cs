using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Agents.DTO;
using Agents.Exception;
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

        public List<JobOffer> GetJobOffersByCompanyId(long companyId)
        {
            return _jobOfferRepository.GetJobOffersByCompanyId(companyId);
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
            JobOffer jobOffer = new JobOffer(jobOfferDTO.CompanyId, jobOfferDTO.Name, jobOfferDTO.Position, jobOfferDTO.Seniority,
                jobOfferDTO.Description, jobOfferDTO.Skills);
            return _jobOfferRepository.Insert(jobOffer);
        }

        public async Task<JobOffer> PublishNewJobOffer(JobOfferDTO jobOfferDTO)
        {
            JobOffer jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
            if (!jobOffer.Publish()) throw new AppException("job offer already published");

            JobOffer publishedJobOffer = await ApiCall.PostAsync(DislinktApiUrl, "", jobOffer, GetCurrentUserApiToken());
            if (publishedJobOffer == null) throw new AppException("failed to publish job offer");

            _jobOfferRepository.Update(jobOffer);
            return publishedJobOffer;
        }

        public JobOffer UpdateJobOffer(JobOfferDTO jobOfferDTO)
        {
            JobOffer jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
            if (jobOffer.Published) PublishJobOfferUpdate(jobOffer);
            return _jobOfferRepository.Update(jobOffer);
        }

        private void PublishJobOfferUpdate(JobOffer jobOffer)
        {
            _ = ApiCall.PutAsync(DislinktApiUrl, "", jobOffer, GetCurrentUserApiToken());
        }

        public void DeleteJobOffer(long id)
        {
            JobOffer jobOffer = _jobOfferRepository.Get(id);
            if (jobOffer.Published) PublishJobOfferDelete(jobOffer);
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

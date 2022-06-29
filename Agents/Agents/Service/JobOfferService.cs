using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;
using Agents.Repository;
using Agents.Utils;
using AutoMapper;

namespace Agents.Service
{
    public class JobOfferService : IJobOfferService
    {
        private const string DislinktApiUrl = "http://localhost:8000/jobOffer";
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public JobOfferService(IJobOfferRepository jobOfferRepository, ISkillRepository skillRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
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
            _ = APICall.PostAsync(DislinktApiUrl, "", jobOffer);
        }

        public JobOffer UpdateJobOffer(JobOfferDTO jobOfferDTO)
        {
            JobOffer jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
            PublishJobOfferUpdate(jobOffer);
            return _jobOfferRepository.Update(jobOffer);
        }

        private void PublishJobOfferUpdate(JobOffer jobOffer)
        {
            _ = APICall.PutAsync(DislinktApiUrl, "", jobOffer);
        }

        public void DeleteJobOffer(long id)
        {
            JobOffer jobOffer = _jobOfferRepository.Get(id);
            PublishJobOfferDelete(jobOffer);
            _jobOfferRepository.Delete(id);
        }

        private void PublishJobOfferDelete(JobOffer jobOffer)
        {
            _ = APICall.DeleteAsync<JobOffer>(DislinktApiUrl, jobOffer.Id.ToString());
        }
    }
}

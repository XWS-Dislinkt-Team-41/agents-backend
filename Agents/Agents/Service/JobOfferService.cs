using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;
using Agents.Repository;
using AutoMapper;

namespace Agents.Service
{
    public class JobOfferService : IJobOfferService
    {
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
            return _jobOfferRepository.Insert(jobOffer);
        }

        public JobOffer UpdateJobOffer(JobOfferDTO jobOfferDTO)
        {
            JobOffer jobOffer = _mapper.Map<JobOffer>(jobOfferDTO);
            return _jobOfferRepository.Update(jobOffer);
        }

        public void DeleteJobOffer(long id)
        {
            _jobOfferRepository.Delete(id);
        }
    }
}

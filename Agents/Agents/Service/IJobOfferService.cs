using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;

namespace Agents.Service
{
    public interface IJobOfferService
    {
        List<JobOffer> GetAllJobOffers();
        JobOffer GetJobOffer(long id);
        List<Skill> GetAllSkills();
        JobOffer PostNewJobOffer(JobOfferDTO jobOfferDTO);
        JobOffer UpdateJobOffer(JobOfferDTO jobOfferDTO);
        void DeleteJobOffer(long id);
    }
}

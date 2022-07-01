using System.Collections.Generic;
using System.Threading.Tasks;
using Agents.DTO;
using Agents.Model;

namespace Agents.Service
{
    public interface IJobOfferService
    {
        List<JobOffer> GetAllJobOffers();
        List<JobOffer> GetJobOffersByCompanyId(long companyId);
        JobOffer GetJobOffer(long id);
        List<Skill> GetAllSkills();
        JobOffer PostNewJobOffer(JobOfferDTO jobOfferDTO);
        Task<JobOffer> PublishNewJobOffer(JobOfferDTO jobOfferDTO);
        JobOffer UpdateJobOffer(JobOfferDTO jobOfferDTO);
        void DeleteJobOffer(long id);
    }
}

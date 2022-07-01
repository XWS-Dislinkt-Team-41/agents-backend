using System.Collections.Generic;
using Agents.Model;

namespace Agents.Repository
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        List<JobOffer> GetJobOffersByCompanyId(long companyId);
    }
}

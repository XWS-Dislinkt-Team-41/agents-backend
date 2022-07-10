using System.Collections.Generic;
using Agents.DTO;

namespace Agents.Service
{
    public interface ICompanyService
    {
        public CompanyDTO AddComment(CommentDTO commentDTO);
        public CompanyDTO AddInterview(InterviewDTO interviewDTO);

        public CompanyDTO AddJobPositionPayment(PaymentDTO paymentDTO);
        public List<CompanyDTO> GetAll();
        public CompanyDTO Get(long companyId);
    }
}

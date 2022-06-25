using System.Collections.Generic;
using System.Linq;
using Agents.DTO;
using Agents.Model;
using Agents.Repository;
using AutoMapper;

namespace Agents.Service
{
    public class CompanyService:ICompanyService
    {

        private ICompanyRepository _companyRepository;
        private IMapper _mapper;
        public CompanyDTO AddComment(CommentDTO commentDTO)
        {
            Comment comment = _mapper.Map<Comment>(commentDTO);
            Company company = _companyRepository.Get(comment.ReviewedCompanyId);
            company.Comments.Add(comment);
            _companyRepository.Save(company);
            return _mapper.Map < CompanyDTO>(company);
        }

        public CompanyDTO AddInterview(InterviewDTO interviewDTO)
        {
            Interview interview = _mapper.Map<Interview>(interviewDTO);
            Company company = _companyRepository.Get(interview.InterviewedCompanyId);
            company.Interviews.Add(interview);
            _companyRepository.Save(company);
            return _mapper.Map<CompanyDTO>(company);
        }

        public CompanyDTO AddJobPositionPayment(PaymentDTO paymentDTO)
        {
            //JobPositionPayment jobPosition = _mapper.Map<JobPositionPayment>(jobPositionPaymentDTO);
            Company company = _companyRepository.Get(paymentDTO.CompanyId); 
            JobPositionPayment oldPositionPayment =
                company.JobPositionsPayments.SingleOrDefault((jobPosition =>
                    jobPosition.JobPosition.Equals(paymentDTO.JobPosition)));
            JobPositionPayment newJobPositionPayment = new JobPositionPayment(_mapper.Map<Payment>(paymentDTO));
            company.JobPositionsPayments.Remove(oldPositionPayment);
            company.JobPositionsPayments.Add(newJobPositionPayment);
            _companyRepository.Save(company);
            return _mapper.Map<CompanyDTO>(company);
        }
    }
}

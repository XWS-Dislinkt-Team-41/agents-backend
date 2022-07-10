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

        public CompanyService(
            ICompanyRepository companyRepository,
            IMapper mapper
        )
        {
            _companyRepository = companyRepository;
            _mapper = mapper;

        }

        public List<CompanyDTO> GetAll()
        {
            return _mapper.Map<List<Company>,List<CompanyDTO>>( _companyRepository.GetAll());
        }

        public CompanyDTO Get(long companyId)
        {
            return _mapper.Map<Company, CompanyDTO>(_companyRepository.Get(companyId));
        }

        public CompanyDTO AddComment(CommentDTO commentDTO)
        {
            Comment comment = _mapper.Map<Comment>(commentDTO);
            Company company = _companyRepository.Get(comment.ReviewedCompanyId);
            company.Comments.Add(comment);
            _companyRepository.Update(company);
            return _mapper.Map < CompanyDTO>(company);
        }

        public CompanyDTO AddInterview(InterviewDTO interviewDTO)
        {
            Interview interview = _mapper.Map<Interview>(interviewDTO);
            Company company = _companyRepository.Get(interview.InterviewedCompanyId);
            company.Interviews.Add(interview);
            _companyRepository.Update(company);
            return _mapper.Map<CompanyDTO>(company);
        }

        public CompanyDTO AddJobPositionPayment(PaymentDTO paymentDTO)
        {
            Company company = _companyRepository.Get(paymentDTO.CompanyId);
            Payment payment = _mapper.Map<Payment>(paymentDTO);
            JobPositionPayment oldPositionPayment =
                company.JobPositionsPayments.SingleOrDefault(jobPosition =>
                    jobPosition.JobPosition.Equals(paymentDTO.JobPosition));
            if (oldPositionPayment != null)
            {
                payment.JobPositionPayment.Reviewers = oldPositionPayment.Reviewers;
                payment.JobPositionPayment.ReviewsNumber = oldPositionPayment.ReviewsNumber;
                payment.JobPositionPayment.Average = oldPositionPayment.Average;
            }


            JobPositionPayment newJobPositionPayment = new JobPositionPayment(payment);
            company.JobPositionsPayments.Remove(oldPositionPayment);
            company.JobPositionsPayments.Add(newJobPositionPayment);
            _companyRepository.Update(company);
            return _mapper.Map<CompanyDTO>(company);
        }
    }
}

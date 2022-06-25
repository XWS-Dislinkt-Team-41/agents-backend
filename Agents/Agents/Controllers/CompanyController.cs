using System.Collections.Generic;
using Agents.Authorization;
using Agents.DTO;
using Agents.Model;
using Agents.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [Authorize(Role.User)]
        [HttpPost]
        [Route("comment")]
        public CompanyDTO AddComment(CommentDTO commentDTO)
        {
            return  _companyService.AddComment(commentDTO);
        }

        [Authorize(Role.User)]
        [HttpPost]
        [Route("interview")]
        public CompanyDTO AddInterview(InterviewDTO interviewDTO)
        {
            return _companyService.AddInterview(interviewDTO);
        }

        [Authorize(Role.User)]
        [HttpPost]
        [Route("payment")]
        public CompanyDTO AddJobPositionPayment(PaymentDTO paymentDTO)
        {
            return _companyService.AddJobPositionPayment(paymentDTO);
        }

    }
}

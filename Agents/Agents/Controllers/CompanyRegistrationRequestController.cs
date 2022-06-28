using System.Collections.Generic;
using System.Linq;
using Agents.Authorization;
using Agents.DTO;
using Agents.Model;
using Agents.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyRegistrationRequestController : ControllerBase
    {
        private readonly ICompanyRegistrationRequestService _requestService;
        private readonly IMapper _mapper;

        public CompanyRegistrationRequestController(ICompanyRegistrationRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [Authorize(Role.User)]
        [HttpPost]
        public ActionResult<CompanyRegistrationRequestDTO> CreateRequest(CompanyRegistrationRequestDTO requestDto)
        {
            var result = _requestService.Create(requestDto);
            return Ok(_mapper.Map<CompanyRegistrationRequestDTO>(result));
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<List<CompanyRegistrationRequestDTO>> GetAllUnansweredRequests()
        {
            var result = _requestService.GetAllUnansweredRequests();
            return Ok(result.Select(r => _mapper.Map<CompanyRegistrationRequestDTO>(r)).ToList());
        }

        [Authorize(Role.Admin)]
        [HttpPut("accept/{id:long}")]
        public IActionResult AcceptRequest(long id, CompanyRegistrationRequestDTO requestDto)
        {
            if (id != requestDto.Id) return BadRequest();
            _requestService.Accept(requestDto);
            return NoContent();
        }

        [Authorize(Role.Admin)]
        [HttpPut("decline/{id:long}")]
        public IActionResult DeclineRequest(long id, CompanyRegistrationRequestDTO requestDto)
        {
            if (id != requestDto.Id) return BadRequest();
            _requestService.Decline(requestDto);
            return NoContent();
        }
    }
}

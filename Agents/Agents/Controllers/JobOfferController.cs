using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly IMapper _mapper;

        public JobOfferController(IJobOfferService jobOfferService, IMapper mapper)
        {
            _jobOfferService = jobOfferService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<JobOfferDTO>> GetAllJobOffers()
        {
            var result = _jobOfferService.GetAllJobOffers();
            return Ok(result.Select(r => _mapper.Map<JobOfferDTO>(r)).ToList());
        }

        [AllowAnonymous]
        [HttpGet("company/{id:long}")]
        public ActionResult<List<JobOfferDTO>> GetJobOffersByCompanyId(long id)
        {
            var result = _jobOfferService.GetJobOffersByCompanyId(id);
            return Ok(result.Select(r => _mapper.Map<JobOfferDTO>(r)).ToList());
        }

        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public ActionResult<JobOfferDTO> GetJobOffer(long id)
        {
            var result = _jobOfferService.GetJobOffer(id);
            return Ok(_mapper.Map<JobOfferDTO>(result));
        }

        [AllowAnonymous]
        [HttpGet("skill")]
        public ActionResult<List<SkillDTO>> GetAllSkills()
        {
            var result = _jobOfferService.GetAllSkills();
            return Ok(result.Select(r => _mapper.Map<SkillDTO>(r)).ToList());
        }

        [Authorize(Role.Owner)]
        [HttpPost]
        public ActionResult<JobOfferDTO> PostNewJobOffer(JobOfferDTO jobOfferDTO)
        {
            var result = _jobOfferService.PostNewJobOffer(jobOfferDTO);
            return Ok(_mapper.Map<JobOfferDTO>(result));
        }

        [Authorize(Role.Owner)]
        [HttpPost("publish")]
        public async Task<ActionResult<JobOfferDTO>> PublishJobOffer(JobOfferDTO jobOfferDTO)
        {
            var result = await _jobOfferService.PublishNewJobOffer(jobOfferDTO);
            return Ok(_mapper.Map<JobOfferDTO>(result));
        }

        [Authorize(Role.Owner)]
        [HttpPut("{id:long}")]
        public ActionResult<JobOfferDTO> UpdateJobOffer(long id, JobOfferDTO jobOfferDTO)
        {
            if (id != jobOfferDTO.Id) return BadRequest();
            var result = _jobOfferService.UpdateJobOffer(jobOfferDTO);
            return Ok(_mapper.Map<JobOfferDTO>(result));
        }

        [Authorize(Role.Owner)]
        [HttpPost("{id:long}")]
        public IActionResult DeleteJobOffer(long id)
        {
            var result = _jobOfferService.GetJobOffer(id);
            if (result == null) return NotFound();
            _jobOfferService.DeleteJobOffer(id);
            return NoContent();
        }


    }
}

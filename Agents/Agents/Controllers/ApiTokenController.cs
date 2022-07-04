using System.Threading.Tasks;
using Agents.Authorization;
using Agents.DTO;
using Agents.Model;
using Agents.Service;
using Microsoft.AspNetCore.Mvc;

namespace Agents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiTokenController : ControllerBase
    {
        private readonly IApiTokenService _apiTokenService;

        public ApiTokenController(IApiTokenService apiTokenService)
        {
            _apiTokenService = apiTokenService;
        }

        //[Authorize(Role.Owner)]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ConnectToDislinktApi(AuthenticateRequestDTO authRequestDto)
        {
            if (await _apiTokenService.ConnectToDislinktApi(authRequestDto))
                return NoContent();
            return BadRequest();
        }
    }
}

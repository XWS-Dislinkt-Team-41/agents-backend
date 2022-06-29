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

        [Authorize(Role.Owner)]
        [HttpPost]
        public async Task<IActionResult> ConnectToDislinktApi(UserDTO userDto)
        {
            if (await _apiTokenService.ConnectToDislinktApi(userDto))
                return NoContent();
            return BadRequest();
        }
    }
}

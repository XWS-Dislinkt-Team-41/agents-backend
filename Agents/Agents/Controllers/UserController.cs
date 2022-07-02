using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _iJwtUtils;

        public UserController(IUserService userService, IMapper mapper, IJwtUtils iJwtUtils)
        {
            _userService = userService;
            _mapper = mapper;
            _iJwtUtils = iJwtUtils;
        }

        [AllowAnonymous]
        [HttpGet]
        public User GetPrincipal()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _iJwtUtils.ValidateJwtToken(token);
            if (userId != null) return _userService.GetById(userId.Value);
            return null;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("requests")]
        public List<User> GetAllUserRequests()
        {
            return _userService.GetAllUserRequests();
        }

        [AllowAnonymous]
        [HttpPost]
        public UserDTO Register(UserDTO userDTO)
        {
            return _mapper.Map<UserDTO>(_userService.Register(userDTO));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public AuthenticateResponseDTO Login(AuthenticateRequestDTO authDTO)
        {
            return _userService.Authenticate(authDTO);
        }


    }
}

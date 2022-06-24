using System.Collections.Generic;
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

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public List<User> GetAll()
        {
            return _userService.GetAll();
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


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Agents.Authorization;
using Agents.DTO;
using Agents.Model;
using Agents.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            return _userService.Register(userDTO);
        }


    }
}

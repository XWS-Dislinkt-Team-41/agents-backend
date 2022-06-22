using System.Collections.Generic;
using System.Linq;
using Agents.Authorization;
using Agents.DTO;
using Agents.Exception;
using Agents.Model;
using AutoMapper;
using Microsoft.Extensions.Options;
using BCrypt.Net;

namespace Agents.Service
{
    public class UserService : IUserService
    {

        private AgentDbContext _context;
        private IJwtUtils _jwtUtils;
        private IMapper _mapper;
        public UserService(
            AgentDbContext context,
            IJwtUtils jwtUtils,
            IMapper mapper
        )
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
    
        }


        public AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);


            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponseDTO(user, jwtToken);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public void Register(UserDTO userDTO)
        {
            // validate
            if (_context.Users.Any(x => x.Username == userDTO.Username))
                throw new AppException("Username '" + userDTO.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(userDTO);
            if (user.Role == Role.Admin)
            {
                user.Confirmed = true;
            }
            else
            {
                user.Confirmed = false;
            }

            // hash password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.PasswordHash);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}

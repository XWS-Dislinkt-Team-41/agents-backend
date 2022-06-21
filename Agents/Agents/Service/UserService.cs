using System.Collections.Generic;
using Agents.Authorization;
using Agents.DTO;
using Agents.Model;
using Microsoft.Extensions.Options;

namespace Agents.Service
{
    public class UserService : IUserService
    {

        private AgentDbContext _context;
        private IJwtUtils _jwtUtils;
        //private readonly AppSettings _appSettings;
        public UserService(
            AgentDbContext context,
            IJwtUtils jwtUtils
            //,IOptions<AppSettings> appSettings
            )
        {
            _context = context;
            _jwtUtils = jwtUtils;
            //_appSettings = appSettings.Value;
        }


        public AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model)
        {
            //var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);
            

            // validate
            //if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            //    throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt token
            //var jwtToken = _jwtUtils.GenerateJwtToken(user);

            //return new AuthenticateResponseDTO(user, jwtToken);
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            //return _context.User;
            return null;
        }

        public User GetById(int id)
        {
            //var user = _context.Users.Find(id);
            //if (user == null) throw new KeyNotFoundException("User not found");
            //return user;
            return null;
        }
    }
}

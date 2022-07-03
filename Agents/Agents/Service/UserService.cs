using System.Collections.Generic;
using Agents.Authorization;
using Agents.DTO;
using Agents.Exception;
using Agents.Model;
using Agents.Repository;
using AutoMapper;

namespace Agents.Service
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;
        private IJwtUtils _jwtUtils;
        private IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IJwtUtils jwtUtils,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _mapper = mapper;

        }

        public AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model)
        {
            var user = _userRepository.GetByUsername(model.Username);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponseDTO(user, jwtToken);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public List<User> GetAllUserRequests()
        {
            return _userRepository.GetAllUnconfirmed();
        }

        public User GetById(int id)
        {
            var user = _userRepository.Get(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public User Register(UserDTO userDTO)
        {
            // validate
            if (_userRepository.GetByUsername(userDTO.Username) != null)
                throw new AppException("Username '" + userDTO.Username + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<UserDTO, User>(userDTO);
            if (user.Role == Role.Admin)
            {
                user.Confirmed = true;
            }
            else
            {
                user.Confirmed = false;
            }

            // hash password
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            // save user
            return _userRepository.Insert(user);
        }
    }
}

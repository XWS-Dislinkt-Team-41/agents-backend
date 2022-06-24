using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;

namespace Agents.Service
{
    public interface IUserService
    {
        public User Register(UserDTO userDTO);
        AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model);
        List<User> GetAll();
        User GetById(int id);
        List<User> GetAllUserRequests();
    }
}

using System.Collections.Generic;
using Agents.DTO;
using Agents.Model;

namespace Agents.Service
{
    public interface IUserService
    {
        AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}

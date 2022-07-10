using System.Threading.Tasks;
using Agents.DTO;

namespace Agents.Service
{
    public interface IApiTokenService
    {
        public Task<bool> ConnectToDislinktApi(AuthenticateRequestDTO authRequestDto);
    }
}

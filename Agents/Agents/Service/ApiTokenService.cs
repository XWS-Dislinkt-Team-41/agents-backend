using System.Threading.Tasks;
using Agents.DTO;
using Agents.Model;
using Agents.Repository;
using Agents.Utils;

namespace Agents.Service
{
    public class ApiTokenService : IApiTokenService
    {
        private const string DislinktApiUrl = "http://localhost:8000/auth/apiToken";
        private readonly IUserRepository _userRepository;

        public ApiTokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> ConnectToDislinktApi(AuthenticateRequestDTO authRequestDto)
        {
            var apiToken = await ApiCall.PostRetObjectAsync(DislinktApiUrl, "", authRequestDto);
            return UpdateUserApiToken(authRequestDto.Username, apiToken as string);
        }

        private bool UpdateUserApiToken(string username, string apiToken)
        {
            User user = _userRepository.GetByUsername(username);
            if (user == null) return false;
            user.ApiToken = apiToken;
            _userRepository.Update(user);
            return true;
        }
    }
}

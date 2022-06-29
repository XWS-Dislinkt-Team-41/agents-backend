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
        public async Task<bool> ConnectToDislinktApi(UserDTO userDto)
        {
            var apiToken = await APICall.PostRetObjectAsync(DislinktApiUrl, "", userDto);
            return UpdateUserApiToken(userDto.Id, apiToken as string);
        }

        private bool UpdateUserApiToken(long userId, string apiToken)
        {
            User user = _userRepository.Get(userId);
            if (user == null) return false;
            user.ApiToken = apiToken;
            _userRepository.Update(user);
            return true;
        }
    }
}

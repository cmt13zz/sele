
using Automation.Services.Models;
using Automation.Test.Cores.API;
using RestSharp;
using RestSharp.Serializers;
using System.Threading.Tasks;



namespace Automation.Services.Services
{
    public class UserService
    {
        private readonly APIClient _client;

        public UserService(APIClient apiClient) {
            _client = apiClient;
        }

        public async Task<RestResponse<GetAllUserResponseDto>> GetUserAsync() {
            return await _client.CreateRequest(APIConstant.GetUserEndPoint)
        }
    }
}
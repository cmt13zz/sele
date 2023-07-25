
using Automation.Services.Models;
using Automation.Services.Models.Requests;
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

        public async Task<RestResponse<GetAllUserResponseDto>> GetUserDetailAsync(string userId) 
        {


            return await _client.CreateRequest($"{APIConstant.GetAccountEndPoint}/{userId}")
                .AddHeader("Authorization", $"Bearer {APIConstant.AccountToken}")
                .AddBody(new UserRequestDto
                {
                    UserId = userId
                })
                .ExecuteGetAsync<GetAllUserResponseDto>();

        }

        public async Task<RestResponse> GenerateTokenAsync(string username, string password) {
            return await _client.CreateRequest(APIConstant.GenerateTokenEndpoint)
            .AddBody(new TokenRequestDto {
                Username = username,
                Password = password
            })
            .ExecutePostAsync();
        }

    }
}

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

        public async Task<RestResponse<GetAllUserResponseDto>> GetUserAsync() 
        {

            _client.CreateRequest(APIConstant.GetUserEndPoint);

            return await _client.CreateRequest(APIConstant.GetUserEndPoint)
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .ExecuteGetAsync<GetAllUserResponseDto>();

        }

        public async Task<RestResponse<GetDetailedUserResponseDto>> GetUserDetailAsync(string userId) 
        {

            _client.CreateRequest($"{APIConstant.GetUserEndPoint}/{userId}");

            return await _client.CreateRequest($"{APIConstant.GetUserEndPoint}/{userId}")
                .AddHeader("Content-Type", ContentType.Json)
                .AddHeader("Accept", ContentType.Json)
                .ExecuteGetAsync<GetDetailedUserResponseDto>();

        }

        public async Task<RestResponse> GenerateTokenAsync(string username, string password) {
            return await _client.CreateRequest(APIConstant.GenerateTokenEndpoint)
            .AddHeader("accept", ContentType.Json)
            .AddHeader("Content-Type", ContentType.Json)
            .AddBody(new TokenRequestDto {
                Username = username,
                Password = password
            })
            .ExecutePostAsync();
        }

        public async Task<RestResponse<GetDetailedUserResponseDto>> CreateUserAsync(string username, string email, string gender, string status) {
            _client.CreateRequest(APIConstant.GetUserEndPoint);

            _client.CreateRequest(APIConstant.GetUserEndPoint)
            .AddHeader("Authorization", $"Bearer {APIConstant.Token}")
            .AddHeader("accept", ContentType.Json)
            .AddHeader("Content-Type", ContentType.Json)
            .AddBody(new AccountDto {
                Name = username,
                Email = email,
                Gender = gender,
                Status = status
            });

            return await  _client.ExecutePostAsync<GetDetailedUserResponseDto>();
        }

        public async Task<RestResponse<GetAllUserResponseDto>> DeleteUserAsync(string userId) {
             _client.CreateRequest($"{APIConstant.GetUserEndPoint}/{userId}");

             return await _client.CreateRequest($"{APIConstant.GetUserEndPoint}/{userId}")
            .AddHeader("Authorization", $"Bearer {APIConstant.Token}")
            .AddHeader("accept", ContentType.Json)
            .AddHeader("Content-Type", ContentType.Json)
            .ExecuteDeleteAsync<GetAllUserResponseDto>();
        }

        public async Task<RestResponse<GetDetailedUserResponseDto>> UpdateUserAsync(string userId,  string email, string gender, string status) {
            return await _client.CreateRequest($"{APIConstant.GetUserEndPoint}/{userId}")
            .AddHeader("Authorization", $"Bearer {APIConstant.Token}")
            .AddHeader("accept", ContentType.Json)
            .AddHeader("Content-Type", ContentType.Json)
            .AddBody(new AccountDto {
                Email = email,
                Gender = gender,
                Status = status
            })
            .ExecutePutAsync<GetDetailedUserResponseDto>();
        }


    }
}
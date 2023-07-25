


using DemoSpecflow.API;
using DemoSpecflow.Configs;
using DemoSpecflow.Models.Requests;
using DemoSpecflow.Models.Responses;
using RestSharp;




namespace DemoSpecflow.Services
{
    public class UserService
    {
        private readonly APIClient _client;

        public UserService(APIClient apiClient) {
            _client = apiClient;
        }

        public async Task<RestResponse<DetailedUserResponseDto>> GetUserDetailAsync(string token, string userId) 
        {

            return await _client.CreateRequest($"{APIConstant.GetAccountEndPoint}/{userId}")
                .AddHeader("Authorization", $"Bearer {token}")
                
                .ExecuteGetAsync<DetailedUserResponseDto>();

        }

        public async Task<RestResponse<TokenResponseDto>> GenerateTokenAsync(string username, string password) {

            return await _client.CreateRequest(APIConstant.GenerateTokenEndpoint)
            .AddBody(new TokenRequestDto {
                Username = username,
                Password = password
            })
            .ExecutePostAsync<TokenResponseDto>();

            
        }

    }
}
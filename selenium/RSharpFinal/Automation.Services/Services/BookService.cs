using Automation.Services.Models;
using Automation.Services.Models.Requests;
using Automation.Test.Cores.API;
using RestSharp;
using RestSharp.Serializers;
using System.Threading.Tasks;


namespace Automation.Services.Services
{
    public class BookService
    {
        private readonly APIClient _client;

        public BookService(APIClient apiClient)
        {
            _client = apiClient;
        }



        public async Task<RestResponse> GenerateTokenAsync(string username, string password)
        {
            return await _client.CreateRequest(APIConstant.GenerateTokenEndpoint)
            .AddBody(new TokenRequestDto
            {
                Username = username,
                Password = password
            })
            .ExecutePostAsync();
        }

        public async Task<RestResponse<BookResponseDto>> GetBookDetailAsync(string isbn) 
        {

            _client.CreateRequest(APIConstant.GetBookEndPoint);

            return await _client.CreateRequest(APIConstant.GetBookEndPoint)
                .AddHeader("Authorization", $"Bearer {APIConstant.AccountToken}")
                .AddBody(new IsbnCollectionRequestDto
                {
                    Isbn = isbn
                })
                .ExecuteGetAsync<BookResponseDto>();

        }

        public async Task<RestResponse<GetAllUserResponseDto>> CreateBookAsync(string userId, string isbn)
        {
            _client.CreateRequest(APIConstant.GetBooksEndPoint);

            _client.CreateRequest(APIConstant.GetBooksEndPoint)
            .AddHeader("Authorization", $"Bearer {APIConstant.AccountToken}")
            .AddBody(new AddBookRequestDto
            {
                UserId = userId,
                CollectionOfIsbns = {
                    Isbn = isbn,
                }
                
            });

            return await _client.ExecutePostAsync<GetAllUserResponseDto>();
        }

        public async Task<RestResponse<GetAllUserResponseDto>> DeleteUserAsync(string isbn, string userId)
        {
            _client.CreateRequest(APIConstant.GetBookEndPoint);

            return await _client.CreateRequest(APIConstant.GetBookEndPoint)
           .AddHeader("Authorization", $"Bearer {APIConstant.AccountToken}")
           .AddBody (new ChangeBookRequestDto
           {
               Isbn = isbn,
               UserId = userId
           })
           .ExecuteDeleteAsync<GetAllUserResponseDto>();
        }

        public async Task<RestResponse<GetAllUserResponseDto>> UpdateBookAsync(string isbn, string userId, string isbnReplace)
        {
            return await _client.CreateRequest($"{APIConstant.GetBooksEndPoint}/{isbn}")
            .AddHeader("Authorization", $"Bearer {APIConstant.AccountToken}")
            .AddBody(new ChangeBookRequestDto
            {
                UserId = userId,
                Isbn = isbnReplace
            })
            .ExecutePutAsync<GetAllUserResponseDto>();
        }

    }
}
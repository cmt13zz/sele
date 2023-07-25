
using DemoSpecflow.API;
using DemoSpecflow.Configs;
using DemoSpecflow.Models.Requests;
using DemoSpecflow.Models.Responses;
using RestSharp;
using RestSharp.Serializers;
using System.Threading.Tasks;


namespace DemoSpecflow.Services
{
    public class BookService
    {
        private readonly APIClient _client;

        public BookService(APIClient apiClient)
        {
            _client = apiClient;
        }


        public async Task<RestResponse<GetDetailedBookResponseDto>> GetBookDetailAsync(string token, string isbn)
        {

            return await _client.CreateRequest($"{APIConstant.GetBookEndPoint}?ISBN={isbn}")
                .AddHeader("Authorization", $"Bearer {token}")
                .ExecuteGetAsync<GetDetailedBookResponseDto>();

        }

        public async Task<RestResponse<AddBookResponseDto>> AddBookAsync(string token, string userId, string isbn)
        {
            return await _client.CreateRequest(APIConstant.GetBooksEndPoint)
            .AddHeader("Authorization", $"Bearer {token}")
            .AddBody(new AddBookRequestDto
            {
                UserId = userId,
                CollectionOfIsbns = new List<CollectionOfIsbn>
                {
                    new CollectionOfIsbn
                    {
                        Isbn = isbn
                    }
                }
            })
            .ExecutePostAsync<AddBookResponseDto>();
        }

        public async Task<RestResponse> DeleteBookAsync(string token, string isbn, string userId)
        {
            return await _client.CreateRequest(APIConstant.GetBookEndPoint)
           .AddHeader("Authorization", $"Bearer {token}")
           .AddBody(new DeleteBookRequestDto
           {
               Isbn = isbn,
               UserId = userId
           })
           .ExecuteDeleteAsync();
        }

        public async Task<RestResponse> DeleteAllBooksAsync(string token, string userId)
        {
            return await _client.CreateRequest($"{APIConstant.GetBooksEndPoint}?UserId={userId}")
           .AddHeader("Authorization ", $"Bearer {token}")
           .ExecuteDeleteAsync();
        }
    }
}
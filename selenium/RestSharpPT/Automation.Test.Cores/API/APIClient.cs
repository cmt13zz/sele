using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Automation.Services.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Automation.Test.Cores.API
{
    public class APIClient
    {
        private readonly RestClient _client;

        public RestRequest Request;

        public APIClient(RestClient client) {
            _client = client;
            Request = new RestRequest();
        }

        public APIClient(string url) {
            _client = new RestClient(url);
            Request = new RestRequest();
        }

        public APIClient SetBasicAuthentication(string username, string password) {
            _client.Authenticator = new HttpBasicAuthenticator(username, password);
            return this;
        }

        public APIClient SetRequestTokenAuthentication(string consumerKey, string consumerSecret) {
            _client.Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret);
            return this;
        }

        public APIClient SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string oauthToken, string oauthTokensecret) {
            _client.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthTokensecret);
            return this;
        }

        public APIClient SetJwtAuthenticator(string token) {
            _client.Authenticator = new JwtAuthenticator(token);
            return this;
        }

        public APIClient ClearAuthenticator() {
            _client.Authenticator = null;
            return this;
        }

        public APIClient CreateRequest(string source="") {
            Request = new RestRequest(source);
            return this;
        }

        public APIClient AddDefaultHeaders(Dictionary<string, string> headers) {
            _client.AddDefaultHeaders(headers);
            return this;
        }

        public APIClient AddHeader(string name, string value) {
            Request.AddHeader(name, value);
            return this;
        }

        public APIClient AddAuthorizationHeader(string value) {
            return AddHeader("Authorization", value);
        }

        public APIClient AddContentTypeHeader(string value=ContentType.Json) {
            return AddHeader("Content-Type", value);
        }

        public APIClient AddParameter(string name, string value) {
            Request.AddParameter(name, value);
            return this;
        }

        public APIClient AddBody(object obj, string contentType=ContentType.Json) {
            string json = JsonConvert.SerializeObject(obj);
            Request.AddStringBody(json, contentType);
            return this;
        }

        public async Task<RestResponse> ExecuteGetAsync() {
            return await _client.ExecuteGetAsync(Request);
        }

        public async Task<RestResponse> ExecuteGetAsync<T>() {
            return await _client.ExecuteGetAsync<T>(Request);
        }


        public async Task<RestResponse> ExecutePostAsync() {
            return await _client.ExecutePostAsync(Request);
        }

        public async Task<RestResponse> ExecutePostAsync<T>() {
            return await _client.ExecutePostAsync<T>(Request);
        }

        public async Task<RestResponse> ExecuteDeleteAsync() {
            Request.Method = Method.Delete;
            return await _client.ExecuteAsync(Request);
        }

        internal Task<RestResponse<GetAllUserResponseDto>> CreateRequest(object getUserEndPoint)
        {
            throw new NotImplementedException();
        }
    }
}
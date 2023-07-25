using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;
using RestSharp.Authenticators.OAuth2;

namespace DemoSpecflow.API
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

        public APIClient SetRequestHeaderAuthentication(string token, string authType="Bearer") {
            _client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, authType);
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


        public async Task<RestResponse<T>> ExecuteGetAsync<T>() {
            return await _client.ExecuteGetAsync<T>(Request);
        }


        public async Task<RestResponse> ExecutePostAsync() {
            return await _client.ExecutePostAsync(Request);
        }

        public async Task<RestResponse<T>> ExecutePostAsync<T>() {
            return await _client.ExecutePostAsync<T>(Request);
        }

        public async Task<RestResponse> ExecuteDeleteAsync() {
            Request.Method = Method.Delete;
            return await _client.ExecuteAsync(Request);
        }

        public async Task<RestResponse<T>> ExecuteDeleteAsync<T>() {
            Request.Method = Method.Delete;
            return await _client.ExecuteAsync<T>(Request);
        }


        public async Task<RestResponse> ExecutePutAsync() {
            Request.Method = Method.Put;
            return await _client.ExecuteAsync(Request);
        }

         public async Task<RestResponse<T>> ExecutePutAsync<T>() {
            Request.Method = Method.Put;
            return await _client.ExecuteAsync<T>(Request);
        }



        public object CreateRequest(object getUserEndPoint)
        {
            throw new NotImplementedException();
        }
    }
}
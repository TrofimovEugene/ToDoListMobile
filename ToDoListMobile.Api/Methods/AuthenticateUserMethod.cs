using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoListMobile.Api.Services;

namespace ToDoListMobile.Api.Methods
{
    public class AuthenticateUserMethod
    {
        private readonly IHttpClientBase _httpClient;

        public AuthenticateUserMethod(IHttpClientBase httpClient)
        {
            _httpClient = httpClient;
        }

        public class Request
        {
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public class Response
        {
            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("idUser")]
            public int IdUser { get; set; }
        }

        public Task<Response> ExecuteAsync(Request request, CancellationToken ct)
        {
            return _httpClient.SendAsync<Request, Response>(HttpMethod.Post, "api/Users/AutorizationUserAndGetToken", request, ct);
        }

    }
}
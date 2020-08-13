using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoListMobile.Api.Services;

namespace ToDoListMobile.Api.Methods
{
    public class RegistryUserMethod
    {
        private readonly IHttpClientBase _httpClient;

        public RegistryUserMethod(IHttpClientBase httpClient)
        {
            _httpClient = httpClient;
        }
        
        public class Request
        {
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("secondName")]
            public string SecondName { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("password")]
            public string Password { get; set; }
            [JsonProperty("organization")]
            public string Organization { get; set; }
            [JsonProperty("role")]
            public string Role { get; set; }
            [JsonProperty("DateOfBirth")]
            public DateTime DateOfBirth { get; set; }
        }
        
        public class Response
        {
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("secondName")]
            public string SecondName { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("password")]
            public string Password { get; set; }
            [JsonProperty("organization")]
            public string Organization { get; set; }
            [JsonProperty("role")]
            public string Role { get; set; }
            [JsonProperty("DateOfBirth")]
            public DateTime DateOfBirth { get; set; }
        }
        public Task<Response> ExecuteAsync(Request request, CancellationToken ct)
        {
            return _httpClient.SendAsync<Request, Response>(HttpMethod.Post, "api/Users", request, ct);
        }
    }
}
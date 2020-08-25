using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoListMobile.Api.Services;

namespace ToDoListMobile.Api.Methods
{
    public class CreateNoteMethod
    {
        private readonly IHttpClientBase _httpClient;

        public CreateNoteMethod(IHttpClientBase httpClient)
        {
            _httpClient = httpClient;
        }

        public class Request
        {
            [JsonProperty("header")]
            public string Header { get; set; }
            [JsonProperty("dateAdded")]
            public DateTime DateAdded { get; set; }
            [JsonProperty("text")]
            public string Text { get; set; }
            [JsonProperty("userId")]
            public int UserId { get; set; }
        }
        
        public class Response
        {
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("header")]
            public string Header { get; set; }
            [JsonProperty("dateAdded")]
            public DateTime DateAdded { get; set; }
            [JsonProperty("text")]
            public string Text { get; set; }
            [JsonProperty("userId")]
            public int UserId { get; set; }
        }

        public Task<Response> ExecuteAsync(Request request, CancellationToken ct)
        {
            return _httpClient.SendAsync<Request, Response>(HttpMethod.Post, "api/Notes", request, ct);
        }
    }
}
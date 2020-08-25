using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoListMobile.Api.Services;
using ToDoListMobile.Api.Shared;

namespace ToDoListMobile.Api.Methods
{
    public class GetNotesMethod
    {
        private readonly IHttpClientBase _httpClient;

        public GetNotesMethod(IHttpClientBase httpClient)
        {
            _httpClient = httpClient;
        }

        public class Request
        {
            public int Id { get; set; }
        }
        
        public class Response : List<NoteModel>
        {
        }

        public Task<Response> ExecuteAsync(Request request, CancellationToken ct)
        {
            return _httpClient.SendAsync<Request, Response>(HttpMethod.Get, $"api/Notes/GetNoteByUserId?id={request.Id}", null, ct);
        }
    }
}
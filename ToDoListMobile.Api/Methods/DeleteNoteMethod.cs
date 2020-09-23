using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ToDoListMobile.Api.Services;
using ToDoListMobile.Api.Shared;

namespace ToDoListMobile.Api.Methods
{
    public class DeleteNoteMethod
    {
        private readonly IHttpClientBase _httpClient;

        public DeleteNoteMethod(IHttpClientBase httpClient)
        {
            _httpClient = httpClient;
        }

        public class Request
        {
            public int Id { get; set; }
        }
        
        public class Response : NoteModel
        {
        }

        public Task<Response> ExecuteAsync(Request request, CancellationToken ct)
        {
            return _httpClient.SendAsync<Request, Response>(HttpMethod.Delete, $"api/Notes/{request.Id}", null, ct);
        }
    }
}
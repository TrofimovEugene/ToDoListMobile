using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ToDoListMobile.Api.Services
{
	interface IHttpClientBase
	{
		string BaseUrl { get; set; }

		string UserAgent { get; set; }

		TimeSpan? Timeout { get; set; }

		string Token { get; set; }


		Task<HttpResponseMessage> SendAsync<TRequest>(
			HttpMethod httpMethod,
			string path,
			TRequest body,
			CancellationToken ct,
			bool needTokenAuthentication = true,
			bool hasResponse = true);

		Task<TResponse> SendAsync<TRequest, TResponse>(
			HttpMethod httpMethod,
			string path,
			TRequest body,
			CancellationToken ct,
			bool needTokenAuthentication = true,
			bool hasResponse = true);

	}
}

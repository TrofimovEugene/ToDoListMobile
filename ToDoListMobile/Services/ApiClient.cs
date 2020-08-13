using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoListMobile.Api.Services;
using ToDoListMobile.Services.User;

namespace ToDoListMobile.Services
{
    public class ApiClient : HttpClientBase
    {
	    public ApiClient()
		{
		}
	    
	    private IUserService _userService;
		private IUserService UserService
		{
			get
			{
				if (_userService != null)
					return _userService;
				_userService = new UserService(this);
				return _userService;
			}
		}


		public override async Task<TResponse> SendAsync<TRequest, TResponse>(
			HttpMethod httpMethod,
			string path,
			TRequest body,
			CancellationToken ct,
			bool needTokenAuthentication = true,
			bool hasResponse = true)
		{
			HttpResponseMessage httpResponseMessage;
			try
			{
				httpResponseMessage = await SendAsync(httpMethod, path, body, ct, needTokenAuthentication, hasResponse).ConfigureAwait(false);
			}
#pragma warning disable 168
			catch (OperationCanceledException e)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new Exception(HttpStatusCode.ServiceUnavailable.ToString());
			}
#pragma warning restore 168

			using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false))
			using (var reader = new StreamReader(stream))
			using (var json = new JsonTextReader(reader))
			{
				var serializer = new JsonSerializer
				{
					NullValueHandling = NullValueHandling.Ignore,
					MissingMemberHandling = MissingMemberHandling.Ignore,
					Culture = CultureInfo.InvariantCulture
				};

				if (httpResponseMessage.IsSuccessStatusCode)
				{
					var responseObject = serializer.Deserialize<TResponse>(json);
					return responseObject;
				}

				throw new Exception(httpResponseMessage.StatusCode.ToString());
			}
		}
    }
}
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoListMobile.Api.Services
{
	public class HttpClientBase : IHttpClientBase
	{
			private HttpClient _httpClient;
			private HttpClient HttpClient
			{
				get
				{
					if (_httpClient != null)
						return _httpClient;
					_httpClient = HttpClientCreator();
					return _httpClient;
				}
			}

			private HttpClient HttpClientCreator()
			{
				var httpClient = new HttpClient();
				if (Timeout != null)
				{
					httpClient.Timeout = Timeout.Value;
				}
				if (string.IsNullOrWhiteSpace(UserAgent))
				{
					httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
				}

				httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

				return httpClient;
			}


			#region Public Propetries

			public string BaseUrl { get; set; }

			public string UserAgent { get; set; }

			public TimeSpan? Timeout { get; set; }

			public string Token { get; set; }

			#endregion


			public async Task<HttpResponseMessage> SendAsync<TRequest>(
				HttpMethod httpMethod,
				string path,
				TRequest body,
				CancellationToken ct,
				bool needTokenAuthentication = true,
				bool hasResponse = true)
			{
				using (var httpRequestMessage = new HttpRequestMessage())
				{
					httpRequestMessage.Method = httpMethod;
					httpRequestMessage.RequestUri = new Uri(string.Concat(BaseUrl, path));

					if (needTokenAuthentication)
					{
						httpRequestMessage.Headers.Add("Authorization", $"Bearer {Token}");
					}

					if (hasResponse)
					{
						httpRequestMessage.Headers.Add("Accept", "application/json");
					}

					string serializedContent = null;
					if (body != null)
					{
						serializedContent = JsonConvert.SerializeObject(body);
						var requestContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");
						httpRequestMessage.Content = requestContent;
					}

#if DEBUG
					Debug.WriteLine("==============Request==============");
					Debug.WriteLine(httpRequestMessage);
					if (httpRequestMessage.Content != null)
					{
						Debug.WriteLine(serializedContent);
					}
#endif

					var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage, ct).ConfigureAwait(false);

#if DEBUG
					Debug.WriteLine("==============Response==============");
					Debug.WriteLine(httpResponseMessage);
					if (httpResponseMessage.Content != null)
					{
						var responseContent = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
						Debug.WriteLine(responseContent);
					}
#endif

					return httpResponseMessage;
				}
			}

			public virtual Task<TResponse> SendAsync<TRequest, TResponse>(
				HttpMethod httpMethod,
				string path,
				TRequest body,
				CancellationToken ct,
				bool needTokenAuthentication = true,
				bool hasResponse = true)
			{
				throw new NotImplementedException();
			}
		}
	}

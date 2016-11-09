using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Gedcomx.Api.Lite.Core
{
	public class FamilySearchSDK
	{
		private HttpClient _client = null;
		private Uri _baseUrl;
		private string _accessToken = null;

		public string AccessToken { get { return _accessToken; } }

		public FamilySearchSDK(string username, string password, string clientId, Environment environment = Environment.Integration)
		{
			IDictionary<String, String> formData = new Dictionary<String, String>();
			formData.Add("grant_type", "password");
			formData.Add("username", username);
			formData.Add("password", password);
			formData.Add("client_id", clientId);

			GetAccessToken(formData, environment);

			InitClient(environment);
		}

		public FamilySearchSDK(string accessToken, Environment environment = Environment.Integration)
		{
			_accessToken = accessToken;
			InitClient(environment);
		}

		private void InitClient(Environment environment)
		{
			switch (environment)
			{
				case Environment.Production:
					_baseUrl = new Uri("https://familysearch.org/");
					break;
				case Environment.Beta:
					_baseUrl = new Uri("https://beta.familysearch.org/");
					break;
				case Environment.Integration:
					_baseUrl = new Uri("https://integration.familysearch.org/");
					break;
				default: // Do nothing
					throw new Exception("Unexpected environment");
			}

			var cookieContainer = new CookieContainer();
			_client = new HttpClient() { BaseAddress = _baseUrl };
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
		}

		private static string GetAcceptContentType(MediaType mediaType)
		{
			switch (mediaType)
			{
				case MediaType.APPLICATION_JSON:
					return "application/json";
				case MediaType.X_GEDCOMX_v1_JSON:
					return "application/x-gedcomx-v1+json";
				case MediaType.X_GEDCOMX_RECORDS_v1_JSON:
					return "application/x-gedcomx-records-v1+json";
				case MediaType.X_GEDCOMX_ATOM_JSON:
					return "application/x-gedcomx-atom+json";
				case MediaType.X_FS_v1_JSON:
					return "application/x-fs-v1+json";
				default:
					throw new Exception("Bad MediaType");
			}
		}

		private string SetMediaType(MediaType mediaType)
		{
			var type = GetAcceptContentType(mediaType);
			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(type));
			return type;
		}

		
		private void GetAccessToken(IDictionary<string, string> formData, Environment environment)
		{
			using (var httpClient = new HttpClient())
			{
				using (var content = new FormUrlEncodedContent(formData))
				{
					content.Headers.Clear();
					content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					string url = "";
					switch (environment)
					{
						case Environment.Production:
							//url = "https://integration.familysearch.org/cis-web/oauth2/v3/token";
							url = "https://ident.familysearch.org/cis-web/oauth2/v3/token";
							break;
						case Environment.Beta:
							url = "https://identbeta.familysearch.org/cis-web/oauth2/v3/token";
							break;
						case Environment.Integration:
							url = "https://identint.familysearch.org/cis-web/oauth2/v3/token";
							break;
						default: // Do nothing
							throw new Exception("Unexpected environment");
					}

					var response = httpClient.PostAsync(url, content).Result;

					if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
					{
						var accessToken = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content.ReadAsStringAsync().Result);

						if (accessToken.ContainsKey("access_token"))
						{
							_accessToken = accessToken["access_token"] as string;
						}

						if (_accessToken == null && accessToken.ContainsKey("token"))
						{
							//workaround to accommodate providers that were built on an older version of the oauth2 specification.
							_accessToken = accessToken["token"] as string;
						}

						if (_accessToken == null)
						{
							throw new Exception("Illegal access token response: no access_token provided.");
						}
					}
					else
					{
						throw new Exception("Unable to obtain an access token.");
					}
				}
			}
		}

		/// <summary>
		/// Gets any content from the api route passed in
		/// </summary>
		/// <param name="apiRoute">any family search api route such as /platform/tree/persons/L11X-X11</param>
		/// <returns>Dynamic object ready for referencing</returns>
		public async Task<dynamic> Get(string apiRoute, MediaType mediaType = MediaType.APPLICATION_JSON)
		{
			SetMediaType(mediaType);
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var response = await _client.GetAsync(url).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject(s);
		}

		public async Task<T> Get<T>(string apiRoute, MediaType mediaType = MediaType.APPLICATION_JSON)
		{
			SetMediaType(mediaType);
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var response = await _client.GetAsync(url).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(s);
		}

		public async Task<HttpResponseMessage> Head(string apiRoute, MediaType mediaType = MediaType.APPLICATION_JSON)
		{
			SetMediaType(mediaType);
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			return await _client.GetAsync(url).ConfigureAwait(false);
		}

		public async Task<dynamic> Put(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			var response = await _client.PutAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			if (string.IsNullOrEmpty(s))
			{
				return response; // No content is sent back, so send the response.
			}
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		public async Task<T> Put<T>(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			var response = await _client.PutAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(s);
		}

		public async Task<dynamic> Post(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			var response = await _client.PostAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			if (string.IsNullOrEmpty(s))
			{
				return response; // No content is sent back, so send the response.
			}
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		public async Task<T> Post<T>(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			var response = await _client.PostAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(s);
		}

		public async Task<dynamic> Delete(string apiRoute)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var response = await _client.DeleteAsync(url).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			if (string.IsNullOrEmpty(s))
			{
				return response; // No content is sent back, so send the response.
			}
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		#region Uncommon Calls

		public async Task<HttpResponseMessage> Post_GetResponse(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			return await _client.PostAsync(url, body).ConfigureAwait(false);
		}

		public async Task<HttpResponseMessage> Post_GetContent(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			var response = await _client.PostAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		public async Task<HttpResponseMessage> Put_GetResponse(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			return await _client.PutAsync(url, body).ConfigureAwait(false);
		}

		public async Task<HttpResponseMessage> Put_GetContent(string apiRoute, string content, MediaType mediaType)
		{
			var url = new Uri(_baseUrl, apiRoute.Replace(_baseUrl.OriginalString, ""));
			var body = new StringContent(content, Encoding.UTF8, SetMediaType(mediaType));
			var response = await _client.PutAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		#endregion
	}
}

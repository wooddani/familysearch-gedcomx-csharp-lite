using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace gedcomx_csharp_lite
{
	public class FamilySearchSDK
	{
		private const string MEDIA_TYPE_GEDCOMX_V1_JSON = "application/x-gedcomx-v1+json";
		private HttpClient _client = null;
		private Uri _baseUrl;
		private string _accessToken = null;

		public string AccessToken { get { return _accessToken; } }

		private void InitClient(bool useSandBox)
		{
			_baseUrl = useSandBox ?
				new Uri("https://sandbox.familysearch.org/platform/collections/tree") : // sandbox
				new Uri("https://familysearch.org/platform/collections/tree"); // production

			var cookieContainer = new CookieContainer();
			_client = new HttpClient() { BaseAddress = _baseUrl };
			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIA_TYPE_GEDCOMX_V1_JSON));
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
		}

		public FamilySearchSDK(string username, string password, string clientId, bool useSandBox = true)
		{
			IDictionary<String, String> formData = new Dictionary<String, String>();
			formData.Add("grant_type", "password");
			formData.Add("username", username);
			formData.Add("password", password);
			formData.Add("client_id", clientId);

			GetAccessToken(formData);

			InitClient(useSandBox);
		}

		public FamilySearchSDK(string accessToken, bool useSandBox = false)
		{
			_accessToken = accessToken;
			InitClient(useSandBox);
		}

		private void GetAccessToken(IDictionary<string, string> formData)
		{
			using (var httpClient = new HttpClient())
			{
				using (var content = new FormUrlEncodedContent(formData))
				{
					content.Headers.Clear();
					content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					var response = httpClient.PostAsync("https://integration.familysearch.org/cis-web/oauth2/v3/token", content).Result;

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
							throw new ApplicationException("Illegal access token response: no access_token provided.");
						}
					}
					else
					{
						throw new ApplicationException("Unable to obtain an access token.");
					}
				}
			}
		}

		/// <summary>
		/// Gets any content from the api route passed in
		/// </summary>
		/// <param name="apiRoute">any family search api route such as /platform/tree/persons/L11X-X11</param>
		/// <returns>Dynamic object ready for referencing</returns>
		public async Task<dynamic> Get(string apiRoute)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var response = await _client.GetAsync(url).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject(s);
		}

		public async Task<T> Get<T>(string apiRoute)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var response = await _client.GetAsync(url).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(s);
		}

		public async Task<HttpResponseMessage> Head(string apiRoute)
		{
			var url = new Uri(_baseUrl, apiRoute);
			return await _client.GetAsync(url).ConfigureAwait(false);
		}

		public async Task<dynamic> Put(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			var response = await _client.PutAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		public async Task<T> Put<T>(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			var response = await _client.PutAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(s);
		}

		public async Task<HttpResponseMessage> Put_GetResponse(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			return await _client.PutAsync(url, body).ConfigureAwait(false);
		}

		public async Task<HttpResponseMessage> Put_GetContent(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			var response = await _client.PutAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		public async Task<dynamic> Post(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			var response = await _client.PostAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			if (string.IsNullOrEmpty(s))
			{
				return response; // No content is sent back, so send the response.
			}
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		public async Task<HttpResponseMessage> Post_GetResponse(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			return await _client.PostAsync(url, body).ConfigureAwait(false);
		}

		public async Task<HttpResponseMessage> Post_GetContent(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			var response = await _client.PostAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<dynamic>(s);
		}

		public async Task<T> Post<T>(string apiRoute, string content)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var body = new StringContent(content, Encoding.UTF8, MEDIA_TYPE_GEDCOMX_V1_JSON);
			var response = await _client.PostAsync(url, body).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(s);
		}

		public async Task<dynamic> Delete(string apiRoute)
		{
			var url = new Uri(_baseUrl, apiRoute);
			var response = await _client.DeleteAsync(url).ConfigureAwait(false);
			var s = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			if (string.IsNullOrEmpty(s))
			{
				return response; // No content is sent back, so send the response.
			}
			return JsonConvert.DeserializeObject<dynamic>(s);
		}
	}
}

using HospitalManagement.Core.Common.Helpers;
using HospitalManagement.Core.Common.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalManagement.Services
{
    public abstract class CommunicatorServiceBase
    {
        public abstract string URL { get; set; }

        private HttpClient _httpClient;
        private ILogger _logger;
        public CommunicatorServiceBase(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CommunicatorServiceBase>();
        }

        public APIResult<T> GetServerResponse<T>(string url, string token = "")
        {
            APIResult<T>? result = new APIResult<T>();
            try
            {
                HttpClient httpClient = GetHttpClient(token);
                HttpResponseMessage responseToolsSupported = httpClient.GetAsync(url).Result;
                if (responseToolsSupported.IsSuccessStatusCode)
                {
                    string data = responseToolsSupported.Content.ReadAsStringAsync().Result;

                    if (data != null)
                    {
                        var a = JsonConvert.DeserializeObject<APIResult<T>>(data);
                        return a;
                    }
                }
                else
                {
                    APIResult<T> data = null;
                    try
                    {
                        data = JsonConvert.DeserializeObject<APIResult<T>>(responseToolsSupported.Content.ReadAsStringAsync().Result);
                    }
                    catch { }
                    if (data != null)
                    {
                        APIResultHelper.UpdateError(data.Message.Message, result);
                    }
                    else
                    {
                        APIResultHelper.UpdateError(responseToolsSupported.ReasonPhrase ?? "Failed to talk to service and reason pharse is missing", result);
                    }
                }
            }
            catch (Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
                _logger.LogCritical(ex, $"Fatal: Failed to get the data from service {ex.Message}");
            }
            return result;
        }

        public APIResult<T> PostToServer<T>(string url, object parameter, string token = "")
        {
            APIResult<T>? result = new APIResult<T>();
            try
            {
                HttpClient httpClient = GetHttpClient(token);
                HttpRequestMessage httpRequestMessage = null;
                if (parameter is MultipartFormDataContent)
                {
                    httpRequestMessage = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(httpClient.BaseAddress, url),
                        Method = HttpMethod.Post,
                        Content = (MultipartFormDataContent)parameter
                    };
                }
                else
                {
                    httpRequestMessage = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(httpClient.BaseAddress, url),
                        Method = HttpMethod.Post,
                        Content = new StringContent(JsonConvert.SerializeObject(parameter), Encoding.UTF8, "application/json")
                    };
                }
                HttpResponseMessage responseToolsSupported = httpClient.SendAsync(httpRequestMessage).Result;
                if (responseToolsSupported.IsSuccessStatusCode)
                {
                    var data = responseToolsSupported.Content.ReadAsStringAsync().Result;

                    if (data != null)
                    {
                        return JsonConvert.DeserializeObject<APIResult<T>>(data);
                    }
                }
                else
                {
                    APIResult<T> data = null;
                    try
                    {
                        data = JsonConvert.DeserializeObject<APIResult<T>>(responseToolsSupported.Content.ReadAsStringAsync().Result);
                    }
                    catch { }
                    if (data != null)
                    {
                        APIResultHelper.UpdateError(data.Message.Message, result);
                    }
                    else
                    {
                        APIResultHelper.UpdateError(responseToolsSupported.ReasonPhrase ?? "Failed to talk to service and reason pharse is missing", result);
                    }
                }
            }
            catch (Exception ex)
            {
                APIResultHelper.UpdateException(ex, result);
                _logger.LogCritical(ex, $"Fatal: Failed to PostToServer for service {ex.Message}");
            }
            return result;
        }

        private HttpClient GetHttpClient(string token) 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(URL);
            _httpClient.Timeout = new TimeSpan(0, 5, 0);
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return _httpClient;
        }
    }
}

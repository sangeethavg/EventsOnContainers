﻿using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebMVC.Infrastructer
{
        public class CustomHttpClient : IHttpClient
        {
        private readonly HttpClient _httpClient;
         public CustomHttpClient() 
        {
            _httpClient = new HttpClient();
        }
            public async Task<string> GetStringAsync(string uri,
                string authorizationToken = null, string authorizationMethod = "Bearer")
            {

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            var response = await _httpClient.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
            }
        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri,
           T item, string authorizationToken, string authorizationMethod)
        {
            var requestMessage = new HttpRequestMessage(method, uri);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item),
                System.Text.Encoding.UTF8, "application/json");
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            var response = await _httpClient.SendAsync(requestMessage);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException(response.Content.ToString());
            }
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            return await DoPostPutAsync(HttpMethod.Post, uri, item,
                authorizationToken, authorizationMethod);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            return await DoPostPutAsync(HttpMethod.Put, uri, item,
                authorizationToken, authorizationMethod);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            return await _httpClient.SendAsync(requestMessage);
        }
    }
    
}
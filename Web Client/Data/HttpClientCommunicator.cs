using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Model;
using System.Text;
using System.Net;
using System;

namespace Data
{
    public class HttpClientCommunicator
    {
        public HttpClient client = new HttpClient();

        public HttpClientCommunicator()
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
        }

        public async Task<string> GetAsync(string url)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new System.Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
            string result = await responseMessage.Content.ReadAsStringAsync();
            return result;
        }
        public async Task<string> AddAsync(Object t, string url)
        {
            string asJson = JsonSerializer.Serialize(t);
            StringContent content = new StringContent(asJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(url, content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new System.Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
            string result = await responseMessage.Content.ReadAsStringAsync();
            return result;
        }

        public async Task DeleteAsync(string url)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new System.Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }

        public async Task PutAsync(Object t, string url)
        {
            string asJson = JsonSerializer.Serialize(t, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            StringContent content = new StringContent(asJson, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(url, content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new System.Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
        }
        public async Task<User> ValidateUser(string username, string password)
        {
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/User/validate?username={username}&password={password}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }
            throw new Exception("User not found");
        }
    }
}
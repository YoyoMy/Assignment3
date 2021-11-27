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
    public class UserService : IUserService
    {
        private HttpClientCommunicator httpClient = new HttpClientCommunicator();

        public UserService(HttpClientCommunicator httpClientCommunicator)
        {
            this.httpClient = httpClientCommunicator;
        }
        public async Task<IList<User>> GetUsersAsync()
        {
            string result = await httpClient.GetAsync("https://localhost:5001/User");
            List<User> users = JsonSerializer.Deserialize<List<User>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return users;
        }
        public async Task AddUserAsync(User user)
        {
            await httpClient.AddAsync(user, "https://localhost:5001/User");
        }
        public async Task<User> ValidateUser(string username, string password)
        {
            try{
                return await httpClient.ValidateUser(username, password);
            } catch(Exception e)
            {
                throw e;
            }
        }
    }
}
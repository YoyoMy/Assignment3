using System.Collections.Generic;
using Model;
using System.Threading.Tasks;
namespace Data
{
    public interface IUserService
    {
        public Task<IList<User>> GetUsersAsync();
        public Task AddUserAsync(User user);
        public Task<User> ValidateUser(string username, string password);
    }
}
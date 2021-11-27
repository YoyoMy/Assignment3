using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
namespace FileData
{
    public interface IUserService
    {
        public Task<DbSet<User>> GetUsersAsync();
        public Task AddUserAsync(User user);
        public Task<User> ValidateUser(string username, string password);
    }
}
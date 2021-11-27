using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Data;
using Microsoft.EntityFrameworkCore;

namespace FileData
{
    public class UserService : IUserService
    {
        
        private FamilyDbContext db {get;set;}

        public UserService(FamilyDbContext db)
        {
            this.db = db;
        }

        public async Task<DbSet<User>> GetUsersAsync()
        {
            return this.db.User;
        }
        public async Task AddUserAsync(User user)
        {
            await db.User.AddAsync(user);
            await db.SaveChangesAsync();
        }
        public async Task<User> ValidateUser(string username, string password)
        {
            return await db.User.FirstOrDefaultAsync(u => u.Username
            .Equals(username) && u.Password.Equals(password));
        }
    }
}
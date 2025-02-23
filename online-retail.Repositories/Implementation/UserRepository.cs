using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using online_retail.Models.ViewModels;
using online_retail.Repositories.Entities;
using online_retail.Repositories.Interface;

namespace online_retail.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext) {
            _dbContext = dbContext;

        }
        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User> GetById(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user=>user.Id==userId);
        }
        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<User> CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUserById(Guid userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return false;  

            _dbContext.Users.Remove(user);  
            await _dbContext.SaveChangesAsync(); 

            return true;  
        }

        public async Task<User> UpdateUserById(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }


    }
}

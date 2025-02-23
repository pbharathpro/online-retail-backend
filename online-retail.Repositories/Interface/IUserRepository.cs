using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_retail.Repositories.Entities;

namespace online_retail.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(Guid userId);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> CreateUser(User user);
        Task<bool> DeleteUserById(Guid userId);
        Task<User> UpdateUserById(User user);

    }

}

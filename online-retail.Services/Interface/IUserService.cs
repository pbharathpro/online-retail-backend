using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_retail.Models.ViewModels;
using online_retail.Repositories.Entities;

namespace online_retail.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetById(Guid userId);
        Task<UserModel> CreateUser(UserModel userModel);
        Task<bool> DeleteUserById(Guid userId);
        Task<UserModel> UpdateUserById(Guid userId,UserModel userModel);
    }
}

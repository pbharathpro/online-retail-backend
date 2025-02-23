using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using online_retail.Models.ViewModels;
using online_retail.Repositories.Entities;
using online_retail.Repositories.Implementation;
using online_retail.Repositories.Interface;
using online_retail.Services.Interface;

namespace online_retail.Services.Implementation
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<List<UserModel>> GetAll()
        {
            List<User> users = await _userRepo.GetAll();
            List<UserModel> userModels = _mapper.Map<List<UserModel>>(users);   
            return userModels;
        }
        public async Task<UserModel> GetById(Guid UserId)
        {
            User users = await _userRepo.GetById(UserId);
            UserModel userModel= _mapper.Map<UserModel>(users);

            return userModel;
        }
        public async Task<User> ValidateUser(string email, string password)
        {
            return await _userRepo.GetUserByEmailAndPassword(email, password);
        }
        public async Task<bool> DeleteUserById(Guid userId)
        {
            return await _userRepo.DeleteUserById(userId);
        }
        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            User newUser = _mapper.Map<User>(userModel);
            newUser.Id = Guid.NewGuid();
            User createdUser = await _userRepo.CreateUser(newUser);
            return _mapper.Map<UserModel>(createdUser);
        }
        public async Task<UserModel> UpdateUserById(Guid userId, UserModel userModel)
        {
            User existingUser = await _userRepo.GetById(userId);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Email = userModel.Email;
            existingUser.Name = userModel.Name;
            existingUser.Password = userModel.Password;
            User updatedUser = await _userRepo.UpdateUserById(existingUser);

            return _mapper.Map<UserModel>(updatedUser);
        }
       
    }
}

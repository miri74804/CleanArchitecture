using clean.Core.Entities;
using clean.Core.Repositories;
using clean.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Service.Services
{
    public class UserService : IuserService
    {
        private readonly IRepositoryManager _manager;

        public UserService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _manager.Users.GetListWithIncludesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _manager.Users.GetByIdWithIncludesAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var u = await _manager.Users.AddAsync(user);
            await _manager.SaveAsync();
            return u;
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var existing = await _manager.Users.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = user.Name;
            existing.Email = user.Email;
            existing.Password = user.Password;

            await _manager.Users.UpdateAsync(existing);
            await _manager.SaveAsync();
            return existing;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var u = await _manager.Users.GetByIdAsync(id);
            if (u == null) return null;

            await _manager.Users.DeleteAsync(u);
            await _manager.SaveAsync();
            return u;
        }
    }
}

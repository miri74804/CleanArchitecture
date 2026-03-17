using clean.Core.Entities;
using clean.Core.Models;
using clean.Core.Repositories;
using clean.Core.Services;

namespace clean.Service.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepositoryManager _manager;

        public UserProfileService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<List<UserProfile>> GetAllAsync()
        {
            return await _manager.UserProfiles.GetListWithUserAsync();
        }

        public async Task<UserProfile> GetProfileByIdAsync(int id)
        {
            return await _manager.UserProfiles.GetByIdWithIncludesAsync(id);
        }

        public async Task<UserProfile> GetProfileByUserIdAsync(int userId)
        {
            return await _manager.UserProfiles.GetByUserIdAsync(userId);
        }

        public async Task<UserProfile> AddProfileAsync(UserProfile profile)
        {
            var user = await _manager.Users.GetByIdAsync(profile.UserId);
            if (user == null) return null;

            var existingProfile = await _manager.UserProfiles.GetByUserIdAsync(profile.UserId);
            if (existingProfile != null) return null;

            var p = await _manager.UserProfiles.AddAsync(profile);
            await _manager.SaveAsync();

            return p;
        }

        public async Task<UserProfile> UpdateProfileAsync(int id, UserProfile profile)
        {
            var existing = await _manager.UserProfiles.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Address = profile.Address;
            existing.BirthDate = profile.BirthDate;

            await _manager.UserProfiles.UpdateAsync(existing);
            await _manager.SaveAsync();

            return existing;
        }

        public async Task<UserProfile> DeleteProfileAsync(int id)
        {
            var p = await _manager.UserProfiles.GetByIdAsync(id);
            if (p == null) return null;

            await _manager.UserProfiles.DeleteAsync(p);
            await _manager.SaveAsync();

            return p;
        }
    }
}
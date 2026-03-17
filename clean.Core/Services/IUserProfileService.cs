using clean.Core.Entities;
using clean.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.Services
{
    public interface IUserProfileService
    {
        Task<List<UserProfile>> GetAllAsync();
        Task<UserProfile> GetProfileByIdAsync(int id);
        Task<UserProfile> GetProfileByUserIdAsync(int userId);
        Task<UserProfile> AddProfileAsync(UserProfile profile);
        Task<UserProfile> UpdateProfileAsync(int id, UserProfile profile);
        Task<UserProfile> DeleteProfileAsync(int id);
    }
}

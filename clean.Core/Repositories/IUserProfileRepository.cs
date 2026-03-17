using clean.Core.Entities;
using clean.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.Repositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<List<UserProfile>> GetListWithUserAsync();
        Task<UserProfile> GetByIdWithIncludesAsync(int id);
        Task<UserProfile> GetByUserIdAsync(int userId);
    }
}

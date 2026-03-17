using clean.Core.Entities;
using clean.Core.Models;
using clean.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Data.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DataContext context) : base(context) { }

        public async Task<List<UserProfile>> GetListWithUserAsync()
        {
            return await _dbSet.Include(p => p.User).ToListAsync();
        }

        public async Task<UserProfile> GetByIdWithIncludesAsync(int id)
        {
            return await _dbSet.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<UserProfile> GetByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}

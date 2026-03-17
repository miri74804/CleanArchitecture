using clean.Core.Entities;
using clean.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public async Task<List<User>> GetListWithIncludesAsync()
        {
            return await _dbSet.Include(u => u.Tasks).Include(u => u.Profile).ToListAsync();
        }

        public async Task<User> GetByIdWithIncludesAsync(int id)
        {
            return await _dbSet.Include(u => u.Tasks).Include(u => u.Profile).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}

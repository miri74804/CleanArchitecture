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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context) { }

        public async Task<List<Category>> GetAllWithTasksAsync()
        {
            return await _dbSet.Include(c => c.Tasks).ToListAsync();
        }

        public async Task<Category> GetByIdWithTasksAsync(int id)
        {
            return await _dbSet.Include(c => c.Tasks).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

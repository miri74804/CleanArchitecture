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
    public class TaskRepository : Repository<TaskItem>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context) { }

        public async Task<List<TaskItem>> GetListWithIncludesAsync()
        {
            return await _dbSet.Include(t => t.user).Include(t => t.Categories).ToListAsync();
        }

        public async Task<TaskItem> GetByIdWithIncludesAsync(int id)
        {
            return await _dbSet.Include(t => t.user).Include(t => t.Categories).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}

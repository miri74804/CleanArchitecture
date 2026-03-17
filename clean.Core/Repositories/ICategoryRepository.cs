using clean.Core.Entities;
using clean.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllWithTasksAsync();
        Task<Category> GetByIdWithTasksAsync(int id);
    }
}

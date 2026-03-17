using clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.Repositories
{
    public interface ITaskRepository : IRepository<TaskItem>
    {
        Task<List<TaskItem>> GetListWithIncludesAsync();
        Task<TaskItem> GetByIdWithIncludesAsync(int id);
    }
}

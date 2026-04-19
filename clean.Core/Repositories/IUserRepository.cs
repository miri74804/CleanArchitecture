using clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetListWithIncludesAsync();
        Task<User> GetByIdWithIncludesAsync(int id);
        Task<User> GetUserByEmailAndPassword(string email, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        IUserProfileRepository UserProfiles { get; }
        ITaskRepository Tasks { get; }
        ICategoryRepository Categories { get; }

        Task SaveAsync();
    }
}

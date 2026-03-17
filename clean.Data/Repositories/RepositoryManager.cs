using clean.Core.Models;
using clean.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IUserRepository Users { get; }
        public IUserProfileRepository UserProfiles { get; }
        public ITaskRepository Tasks { get; }
        public ICategoryRepository Categories { get; }

        public RepositoryManager(DataContext context, IUserRepository userRepository, IUserProfileRepository userProfileRepository, ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            Users = userRepository;
            UserProfiles = userProfileRepository;
            Tasks = taskRepository;
            Categories = categoryRepository;
        }

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}

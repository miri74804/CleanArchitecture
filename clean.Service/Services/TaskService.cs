using clean.Core.Entities;
using clean.Core.Repositories;
using clean.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _manager;

        public TaskService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _manager.Tasks.GetListWithIncludesAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _manager.Tasks.GetByIdWithIncludesAsync(id);
        }

        public async Task<TaskItem> AddTaskAsync(TaskItem task)
        {
            var user = await _manager.Users.GetByIdAsync(task.userId);
            if (user == null) return null;

            var newTask = await _manager.Tasks.AddAsync(task);
            await _manager.SaveAsync();
            return newTask;
        }

        public async Task<TaskItem> UpdateTaskAsync(int id, TaskItem task)
        {
            var existing = await _manager.Tasks.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Title = task.Title;
            existing.IsCompleted = task.IsCompleted;
            existing.userId = task.userId; 

           await _manager.Tasks.UpdateAsync(existing);
            await _manager.SaveAsync();

            return existing;
        }

        public async Task<TaskItem> DeleteTaskAsync(int id)
        {
            var task = await _manager.Tasks.GetByIdAsync(id);
            if (task == null) return null;

           await _manager.Tasks.DeleteAsync(task);
           await _manager.SaveAsync(); 

            return task;
        }
    }
}

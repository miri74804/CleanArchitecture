using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clean.Core.Entities;
using clean.Core.Models;
using clean.Core.Repositories;
using clean.Core.Services;

namespace clean.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _manager.Categories.GetAllWithTasksAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _manager.Categories.GetByIdWithTasksAsync(id);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var newCategory = await _manager.Categories.AddAsync(category);
            await _manager.SaveAsync();
            return newCategory;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            var existing = await _manager.Categories.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = category.Name;

            await _manager.Categories.UpdateAsync(existing);
            await _manager.SaveAsync();
            return existing;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var category = await _manager.Categories.GetByIdAsync(id);
            if (category == null) return null;

            await _manager.Categories.DeleteAsync(category);
            await _manager.SaveAsync();
            return category;
        }
    }
}
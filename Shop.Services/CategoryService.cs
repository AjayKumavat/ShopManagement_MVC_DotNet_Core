using Shop.Database.Repositories;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategoryById(int id);
        Category AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category AddCategory(Category category)
        {
            Category _category = new Category
            {
                Name = category.Name,
                CreatedBy = category.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = category.IsActive
            };
            _categoryRepository.Add(_category);
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category category = await GetCategoryById(id);
            if (category != null)
            {
                _categoryRepository.Delete(category);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Category _category = await GetCategoryById(category.Id);
            if(category != null)
            {
                _category.Name = category.Name;
                _category.CreatedBy = category.CreatedBy;
                _category.CreatedDate = category.CreatedDate;
                _category.ModifiedDate = DateTime.Now;
                _category.IsActive = category.IsActive;
                _categoryRepository.Update(_category);
                return category;
            }
            return category;
        }
    }
}

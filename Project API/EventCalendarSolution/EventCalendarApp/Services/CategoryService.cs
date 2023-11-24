using EventCalendarApp.Exceptions;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using EventCalendarApp.Repositories;
using EventCalendarApp.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Design;

namespace EventCalendarApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<int, Category> _categoryRepository;
        public CategoryService(IRepository<int, Category> categoryRepository)

        {
            _categoryRepository = categoryRepository;

        }

        /// <summary>
        /// getting the list of categories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NocategoriesAvailableException"></exception>
        public List<Category> GetCategories()
        {
            var category = _categoryRepository.GetAll();
            if (category != null)
            {
                return category.ToList();
            }
            throw new NocategoriesAvailableException();

        }
        /// <summary>
        /// adding the category to database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="NameAlreadyExist"></exception>
         /*public Category Add(Category category)
         {
             if (IsCategoryNameUnique(category.Name))
             {
                 return _categoryRepository.Add(category);
             }
             throw new NameAlreadyExist();
         }
        /// <summary>
        /// it checks whether the category is unique or not
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
         private bool IsCategoryNameUnique(String categoryName)
         {

             return !_categoryRepository.GetAll().Any(c => c.Name == categoryName);

         }*/

        
        public Category Add(Category category)
        {
            var result = _categoryRepository.Add(category);
            return result;
        }
        
    }

}

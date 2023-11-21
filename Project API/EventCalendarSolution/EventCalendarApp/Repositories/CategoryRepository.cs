using EventCalendarApp.Contexts;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventCalendarApp.Repositories
{
    public class CategoryRepository : IRepository<int, Category>
    {
        private readonly CalendarContext _context;

        public CategoryRepository(CalendarContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adding the caterogy
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Category Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        /// <summary>
        /// deleting the category by Id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Category Delete(int key)
        {
            var category = GetById(key);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return category;
            }
            return null;
        }
        /// <summary>
        /// getting all category
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAll()
        {
            if (_context.Categories.Count() == 0)
                return null;
            return _context.Categories.ToList();
        }

        public Category GetById(int key)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == key);
            return category;
        }
        /// <summary>
        /// Updating the category
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Category Update(Category entity)
        {
            var category = GetById(entity.Id);
            if (category != null)
            {
                _context.Entry<Category>(category).State = EntityState.Modified;
                _context.SaveChanges();
                return category;
            }
            return null;
        }
    }
}
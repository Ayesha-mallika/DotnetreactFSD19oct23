using EventCalendarApp.Contexts;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventCalendarApp.Repositories
{
    public class ReminderRepository : IRepository<int, Reminder>
    {
        private readonly CalendarContext _context;

        public ReminderRepository(CalendarContext context)
        {
            _context = context;
        }

        public Reminder Add(Reminder entity)
        {
            _context.Reminders.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Reminder Delete(int key)
        {
            var reminder = GetById(key);
            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                _context.SaveChanges();
                return reminder;
            }
            return null;
        }

        public IList<Reminder> GetAll()
        {
            if (_context.Reminders.Count() == 0)
                return null;
            return _context.Reminders.ToList();
        }

        /*public IList<Reminder> GetAll(Func<Reminder, bool> value)
        {
            if (value != null)
                return _context.Reminders.Where(value).ToList();

            return _context.Reminders.ToList();
        }*/

        public Reminder GetById(int key)
        {
            var reminder = _context.Reminders.SingleOrDefault(r => r.Id == key);
            return reminder;
        }

        public Reminder Update(Reminder entity)
        {
            var reminder = GetById(entity.Id);
            if (reminder != null)
            {
                _context.Entry<Reminder>(reminder).State = EntityState.Modified;
                _context.SaveChanges();
                return reminder;
            }
            return null;
        }
    }
}
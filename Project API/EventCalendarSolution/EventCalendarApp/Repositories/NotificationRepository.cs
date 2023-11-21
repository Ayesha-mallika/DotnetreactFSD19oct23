using EventCalendarApp.Contexts;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventCalendarApp.Repositories
{
    public class NotificationRepository : IRepository<int, Notification>
    {
        private readonly CalendarContext _context;

        public NotificationRepository(CalendarContext context)
        {
            _context = context;
        }

        public Notification Add(Notification entity)
        {
            _context.Notifications.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Notification Delete(int key)
        {
            var notification = GetById(key);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                _context.SaveChanges();
                return notification;
            }
            return null;
        }
        public IList<Notification> GetAll()
        {
            if (_context.Notifications.Count() == 0)
                return null;
            return _context.Notifications.ToList();
        }

       /* public IList<Notification> GetAll(Func<Notification, bool> value=null)
        {
            if (value != null)
                return _context.Notifications.Where(value).ToList();

            return _context.Notifications.ToList();
        }
       */
        public Notification GetById(int key)
        {
            return _context.Notifications.SingleOrDefault(n => n.Id == key);
        }

        public Notification Update(Notification entity)
        {
            var notification = GetById(entity.Id);
            if (notification != null)
            {
                _context.Entry(notification).State = EntityState.Modified;
                _context.SaveChanges();
                return notification;
            }
            return null;
        }
    }
}

using EventCalendarApp.Contexts;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCalendarApp.Repositories
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly CalendarContext _context;

        public EventRepository(CalendarContext context)
        {
            _context = context;
        }
        /// <summary>
        /// adding the events 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Event Add(Event entity)
        {
            _context.Events.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        /// <summary>
        /// deleting the events by Id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Event Delete(int key)
        {
            var events = GetById(key);
            if (events != null)
            {
                _context.Events.Remove(events);
                _context.SaveChanges();
                return events;
            }
            return null;
        }
        /// <summary>
        /// getting all events
        /// </summary>
        /// <returns></returns>

        public IList<Event> GetAll()
        {
            if (_context.Events.Count() == 0)
                return null;
            return _context.Events.ToList();
        }

        public Event GetById(int key)
        {
            var events = _context.Events.SingleOrDefault(e => e.Id == key);
            return events;
        }
        /// <summary>
        /// Updating the evnets
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Event Update(Event entity)
        {
            var events = GetById(entity.Id);
            if (events != null)
            {
                _context.Entry<Event>(events).State = EntityState.Modified;
                _context.SaveChanges();
                return events;
            }
            return null;
        }
    }
}
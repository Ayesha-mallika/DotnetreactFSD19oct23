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
        /// Add the event or to create an event
        /// </summary>
        /// <param name="entity">event object that has to be added</param>
        /// <returns>entity</returns>
        public Event Add(Event entity)
        {
            _context.Events.Add(entity);
            _context.SaveChanges(); //this will make the change in Db
            return entity;
        }
        /// <summary>
        /// to remove event by its id
        /// </summary>
        /// <param name="key">the id of the event to be deleted</param>
        /// <returns>the deleted event</returns>
        public Event Delete(int key)
        {
            var events = GetById(key);
            if (events != null)
            {
                _context.Events.Remove(events);
                _context.SaveChanges();//this will delete the event in db
                return events;
            }
            return null;
        }
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

        //public Event Update(Event entity)
        //{
        //    var events = GetById(entity.Id);
        //    if (events != null)
        //    {
        //        _context.Entry<Event>(events).State = EntityState.Modified;
        //        _context.SaveChanges();
        //        return events;
        //    }
        //    return null;
        //}
        public Event Update(Event entity)
        {
            var events = GetById(entity.Id);
            if (events != null)
            {
                // Update properties as needed
                events.title = entity.title;
                events.Description = entity.Description;
                events.StartDateTime = entity.StartDateTime;
                events.NotificationDateTime = entity.NotificationDateTime;
                events.Location = entity.Location;
                events.IsRecurring = entity.IsRecurring;
                _context.Events.Update(events);
                _context.SaveChanges();
                return events;
            }
            return null;
        }
    }
}
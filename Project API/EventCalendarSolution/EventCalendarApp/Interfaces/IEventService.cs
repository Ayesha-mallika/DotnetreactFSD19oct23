using EventCalendarApp.Models;
using EventCalendarApp.Models.DTOs;

namespace EventCalendarApp.Interfaces
{
    public interface IEventService
    {

        /// <summary>
        /// interface for EventService
        /// </summary>
        /// <returns></returns>
        List<IGrouping<int, Event>> GetEvents(string userId);
        Event Add(Event events);
        Event Remove(Event events);
        Event Update(Event events);
    }
}
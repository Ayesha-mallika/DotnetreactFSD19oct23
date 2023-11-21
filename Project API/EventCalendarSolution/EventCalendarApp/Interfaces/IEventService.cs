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
        List<Event> GetEvents();
        Event Add(Event events);
        Event Remove(Event events);
        Event Update(Event events);
        /*void ShareEventViaEmail(int eventId, List<User> recipients, string message);
        void ShareEventViaCalendarInvite(int eventId, List<User> recipients);
        void SendCalendarInvite(string organizerEmail, List<string> attendees, string subject, DateTime startTime, DateTime endTime);
        void SendEmail(string to, string subject, string body);*/
    }
}
using EventCalendarApp.Exceptions;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using EventCalendarApp.Models.DTOs;
using EventCalendarApp.Repositories;
using Microsoft.Extensions.Logging;


namespace EventCalendarApp.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<int, Event> _eventRepository;
        private readonly IRepository<int, Reminder> _reminderRepository;
        private readonly IRepository<int, Notification> _notificationRepository;

        
        public EventService(IRepository<int, Event> eventRepository, IRepository<int, Reminder> reminderRepository, IRepository<int,
            Notification> notificationRepository)
        {
            _eventRepository = eventRepository;
            _reminderRepository = reminderRepository;
            _notificationRepository = notificationRepository;


        }
        /// <summary>
        /// adding the events to repository
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public Event Add(Event events)
        {
            
            var addedEvent = _eventRepository.Add(events);

            // Add reminder
            var reminder = new Reminder
            {
                Message = "Your event is coming up!",
                ReminderDateTime = events.StartDateTime,
                EventId = addedEvent.Id,
                //UserEmail = user.Email

            };
            _reminderRepository.Add(reminder);

            // Add notification
            var notification = new Notification

            {
                Content = "Event Notification",
                NotificationDateTime = SetNotificationTimeLogic(events.StartDateTime),
                EventId = addedEvent.Id,
                // ReminderId=reminder.Id
                //UserEmail = user.Email
            };
            _notificationRepository.Add(notification);

            return addedEvent;
        }
        private static DateTime SetNotificationTimeLogic(DateTime eventsStartDateTime) => eventsStartDateTime.AddMinutes(-30);


        /// <summary>
        /// getting the list of all events
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NoEventsAvailableException"></exception>

        public List<Event> GetEvents()
        {
            var events = _eventRepository.GetAll();
            if (events != null)
            {
                return events.ToList();
            }
            throw new NoEventsAvailableException();
        }
        /// <summary>
        /// removing the events from repository
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public Event Remove(Event events)
        {
            var EventId = _eventRepository.GetAll().FirstOrDefault(e => e.Id == events.Id);
            if (EventId != null)
            {
                var result = _eventRepository.Delete(EventId.Id);
                if (result != null) return result;
            }
            return EventId;
        }
        /// <summary>
        /// updating the events from repository
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public Event Update(Event events)
        {
            var EventId = _eventRepository.GetAll().FirstOrDefault(e => e.Id == events.Id);
            if (EventId != null)
            {
                var result = _eventRepository.Update(events);
                if (result != null) return result;
            }
            return EventId;
        }

        public void SendEmail(string to, string subject, string body)
        {
            
            Console.WriteLine($"Sending email to: {to}\nSubject: {subject}\nBody: {body}");
        }

        public void SendCalendarInvite(string organizerEmail, List<string> attendees, string subject, DateTime startTime, DateTime endTime)
        {
            
            Console.WriteLine($"Sending calendar invite\nOrganizer: {organizerEmail}\nAttendees: {string.Join(", ", attendees)}\nSubject: {subject}\nStart Time: {startTime}\nEnd Time: {endTime}");
        }

        public void ShareEventViaEmail(int eventId, List<User> recipients, string message)
        {
            Event sharedEvent = _eventRepository.GetById(eventId);

            foreach (var recipient in recipients)
            {
                SendEmail(recipient.Email, $"Invitation: {sharedEvent.title}", message);
            }
        }

        public void ShareEventViaCalendarInvite(int eventId, List<User> recipients)
        {
            Event sharedEvent = _eventRepository.GetById(eventId);

            List<string> attendeeEmails = recipients.Select(user => user.Email).ToList();

            /*SendCalendarInvite(
                organizerEmail: sharedEvent.SharedWith.First().Email,
                attendees: attendeeEmails,
                subject: sharedEvent.title,
                startTime: sharedEvent.StartDateTime,
                endTime: sharedEvent.EndDateTime
            );*/
        }
    }
}
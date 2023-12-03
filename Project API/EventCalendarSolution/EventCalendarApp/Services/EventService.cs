using EventCalendarApp.Exceptions;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using EventCalendarApp.Models.DTOs;
using EventCalendarApp.Repositories;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;

namespace EventCalendarApp.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<int, Event> _eventRepository;
        public EventService(IRepository<int, Event> eventRepository)
        {
            _eventRepository = eventRepository;

        }
        /// <summary>
        /// add the event to the database
        /// </summary>
        /// <param name="events">event to be added</param>
        /// <returns>returns event</returns>
        public Event Add(Event events)
        {
            //ScheduleAndSendEmail(DateTime.Parse(result.NotificationDateTime), result);
            //// ScheduleAndSendEmail(DateTime.Parse(result.StartDateTime).Min(-5), result);
            //return result;
            var result = _eventRepository.Add(events);
            // Assuming ScheduleAndSendEmail has a signature like: void ScheduleAndSendEmail(DateTime notificationDateTime, EventResult result)
            ScheduleAndSendEmail(result.NotificationDateTime, result);
            return result;
        }
        public void ScheduleAndSendEmail(DateTime targetTime, Event events)
        {
            // Calculate the delay until the target time
            int delayMilliseconds = (int)(targetTime - DateTime.Now).TotalMilliseconds;

            // Create a Timer with a callback function that sends the email
            Timer timer = new Timer(state =>
            {
                // Your email sending logic here
                string to = events.Email;
                string subject = "Event Scheduled Email";
                string body = ($"Dear All \n Greetings!!! \nYou have '{events.title}' starts from '{events.StartDateTime}' and ended at '{events.EndDateTime}' \n Don't miss it ");

                SendNotificationEmail(to, subject, body);
            }, null, delayMilliseconds, Timeout.Infinite);
        }
        public void SendNotificationEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                string email = "ayeshajasmeen79@gmail.com";
                string password = "aoamaglwoxwpmlxh";

                // Create the email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;

                // Set up SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(email, password);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;

                // Send the email
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
        /// <summary>
        /// Share an event with specified email addresses
        /// </summary>
        /// <param name="eventId">The id of the event to be shared</param>
        /// <param name="recipientEmails">List of recipient emails</param>
        /// <returns>True if sharing is successful, false otherwise</returns>
        public bool ShareEvent(int eventId, List<string> recipientEmails)
        {
            // Retrieve the event to be shared
            var eventToShare = _eventRepository.GetById(eventId);
            if (eventToShare != null)
            {
                // Customize the email subject and body for sharing
                string subject = "Shared Event: " + eventToShare.title;
                string body = $"Dear Recipient,\n\nYou have been invited to the event '{eventToShare.title}' scheduled for {eventToShare.StartDateTime}. Don't miss it!";

                // Loop through recipient emails and send individual emails
                foreach (var recipientEmail in recipientEmails)
                {
                    SendNotificationEmail(recipientEmail, subject, body);
                }

                return true; // Sharing successful
            }

            return false; // Event not found
        }
        /// <summary>
        /// List of all created events
        /// </summary>
        /// <param name="userId">get the events list of specific user</param>
        /// <returns></returns>
        /// <exception cref="NoEventsAvailableException"></exception>
        public List<IGrouping<int, Event>> GetEvents(string userId)
        {
            var events = _eventRepository.GetAll().Where(c => c.Email == userId).ToList();
            var category = events.GroupBy(c => c.CategoryId).ToList();
            if (category != null)
            {
                return category;
            }
            throw new NoEventsAvailableException();
        }
        public IList<Event> GetPublicEvents(string access)
        {
            var events = _eventRepository.GetAll().Where(e => e.Access == access).ToList();
            if (events != null)
            {
                return events;
            }
            throw new NoEventsAvailableException();
        }

        /// <summary>
        /// removing the events from repository
        /// </summary>
        /// <param name="events">from id event to be deleted</param>
        /// <returns>deleted event</returns>
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
        /// <param name="events">get event from id and event to be updated</param>
        /// <returns>updated event</returns>
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
    }
}
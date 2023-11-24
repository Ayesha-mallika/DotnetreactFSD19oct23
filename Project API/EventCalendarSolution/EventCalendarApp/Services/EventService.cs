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
            var result = _eventRepository.Add(events);
            ScheduleAndSendEmail(DateTime.Parse(result.NotificationDateTime), result);
            // ScheduleAndSendEmail(DateTime.Parse(result.StartDateTime).Min(-5), result);
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
                string body = $"You have {events.title} at {events.StartDateTime}. \n Don't miss it out.";

                SendNotificationEmail(to, subject, body);
            }, null, delayMilliseconds, Timeout.Infinite);
        }
        public void SendNotificationEmail(string recipientEmail, string subject, string body)
        {

            string email = "ayeshajasmeen79@gmail.com";
            string password = "aoamaglwoxwpmlxh";

            // Recipient email
            string toEmail = recipientEmail;

            // Create the email message
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email);
            mail.To.Add(toEmail);
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
    }
}
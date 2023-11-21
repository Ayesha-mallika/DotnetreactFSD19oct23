using EventCalendarApp.Exceptions;
using EventCalendarApp.Interfaces;
using EventCalendarApp.Models;
using EventCalendarApp.Repositories;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace EventCalendarApp.Services
{
    public class NotificationService:INotificationService
    {

        private readonly IRepository<int, Notification> _notificationRepository;
        private readonly IRepository<int, Event> _eventRepository;
        private readonly IEventService _eventservice;
        public NotificationService(IRepository<int, Notification> repository, IRepository<int, Event> eventRepository, IEventService eventservice)
        {
            _notificationRepository = repository;
            _eventRepository = eventRepository;
            _eventservice = eventservice;
        }
        public Notification Add(Notification notification)
        {
           /* //var addedEvent = _eventservice.Add(events);
            var notificatin = new Notification
            {
                Content = "Event Notification",
                NotificationDateTime = DateTime.Now, // Set your notification time logic
                //EventId = addedEvent.Id
                //UserEmail = user.Email
            };
            _notificationRepository.Add(notification);*/
            var result = _notificationRepository.Add(notification);
                return result;
        }
        public List<Notification> GetNotifications()
        {
            var notification = _notificationRepository.GetAll();
            if (notification != null)
            {
                return notification.ToList();
            }
            throw new NoEventsAvailableException();
        }



        /* public Notification SendNotification(Notification notification)
         {
             notification.NotificationDateTime = DateTime.Now;
             return _notificationRepository.Add(notification);
         }
         public IList<Notification> GetNotificationsByUser(string email)
         {
             return _notificationRepository.GetAll(n => n.Email == email);


         }*/
    }
}

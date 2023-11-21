using EventCalendarApp.Exceptions;
using EventCalendarApp.Models;
using EventCalendarApp.Repositories;
using Microsoft.EntityFrameworkCore;
using EventCalendarApp.Contexts;
using EventCalendarApp.Interfaces;

namespace EventCalendarApp.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IRepository<int,Reminder> _reminderRepository;
        private readonly INotificationService _notificationService;

        public ReminderService(IRepository<int, Reminder> reminderRepository, INotificationService notificationService)
        {
            _reminderRepository = reminderRepository;
            _notificationService = notificationService;
        }

        public List<Reminder> GetReminders()
        {
            var reminder = _reminderRepository.GetAll();
            if (reminder != null)
            {
                return reminder.ToList();
            }
            throw new NoEventsAvailableException();

        }

        public Reminder Add(Reminder reminder)
        {
            var result = _reminderRepository.Add(reminder);
            return result;
        }

        /*public Reminder CreateReminder(Reminder reminder)
        {
            // Assuming some logic to determine how to send the notification based on the type
            if (reminder.PreferredNotification == Reminder.NotificationType.Email)
            {
                // Send email notification logic
                // You may want to integrate with an email service here
                var emailNotification = new Notification
                {
                    Content = $"Email notification for Reminder: {reminder.Message}",
                    Email = reminder.Email,
                };
                _notificationService.SendNotification(emailNotification);
            }
            else if (reminder.PreferredNotification == Reminder.NotificationType.InApp)
            {
                // Send in-app notification logic
                // You may want to integrate with an in-app notification service here
                var inAppNotification = new Notification
                {
                    Content = $"In-app notification for Reminder: {reminder.Message}",
                    Email = reminder.Email,
                };
                _notificationService.SendNotification(inAppNotification);
            }
            else if (reminder.PreferredNotification == Reminder.NotificationType.PushNotifications)
            {
                // Send push notification logic
                // You may want to integrate with a push notification service here
                var inAppNotification = new Notification
                {
                    Content = $"In-app notification for Reminder: {reminder.Message}",
                    Email = reminder.Email,
                };
                _notificationService.SendNotification(inAppNotification);
            }
            else if (reminder.PreferredNotification == Reminder.NotificationType.PushNotifications)
            {
                // Send push notification logic
                // You may want to integrate with a push notification service here
                var pushNotification = new Notification
                {
                    Content = $"Push notification for Reminder: {reminder.Message}",
                    Email = reminder.Email,
                };
                _notificationService.SendNotification(pushNotification);
            }

            return _reminderRepository.Add(reminder);
        }

        public Reminder UpdateReminder(Reminder reminder)
        {
            // Similar logic as CreateReminder for handling different notification types
            // ...

            return _reminderRepository.Update(reminder);
        }

        public Reminder GetReminderById(int reminderId)
        {
            return _reminderRepository.GetById(reminderId);
        }


        public IList<Reminder> GetRemindersByUser(string email)
        {
            return _reminderRepository.GetAll(r => r.Email == email);
        }

        //public Reminder DeleteReminder(int reminderId)
        //{
        //    return _reminderRepository.Delete(reminderId);
        //}*/
    }
}



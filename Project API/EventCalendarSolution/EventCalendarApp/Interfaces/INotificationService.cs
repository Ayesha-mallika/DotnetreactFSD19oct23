using EventCalendarApp.Models;

namespace EventCalendarApp.Interfaces
{
    public interface INotificationService
    {
        Notification Add(Notification notification);
        public List<Notification> GetNotifications();
        //Notification SendNotification(Notification notification);
        //IList<Notification> GetNotificationsByUser(string email);

    }
}

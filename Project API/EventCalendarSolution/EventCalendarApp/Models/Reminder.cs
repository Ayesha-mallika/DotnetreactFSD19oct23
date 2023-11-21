using System.ComponentModel.DataAnnotations.Schema;
using EventCalendarApp.Models.DTOs;
namespace EventCalendarApp.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? ReminderDateTime { get; set; }
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event? Event { get; set; }

        /*[ForeignKey("UserEmail")]
        public string UserEmail { get; set; }
        public UserDTO? User { get; set; }*/



        //public List<Notification>? Notifications { get; set; }
        /*public enum NotificationType
        {
            Email,
            InApp,
            PushNotifications
        }

        public NotificationType PreferredNotification { get; set; }*/
    }

}
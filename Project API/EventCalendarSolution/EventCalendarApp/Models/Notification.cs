using System.ComponentModel.DataAnnotations.Schema;
using EventCalendarApp.Models.DTOs;

namespace EventCalendarApp.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? NotificationDateTime { get; set; }
        //public int ReminderId { get; set; }

        //[ForeignKey("ReminderId")]
        //public Reminder? Reminder { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event? Event { get; set; }


        /*[ForeignKey("RminderId")]
        public int ReminderId { get; set; }
        public Reminder? Reminder { get; set; }

        */

    }
}   

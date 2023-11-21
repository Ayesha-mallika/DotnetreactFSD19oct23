using EventCalendarApp.Models;
using System.Collections.Generic;

namespace EventCalendarApp.Interfaces
{
    public interface IReminderService
    {
        Reminder Add(Reminder reminder);
        //Reminder Update(Reminder reminder);
        public List<Reminder> GetReminders();
        //IList<Reminder> GetRemindersByUser(string email);

        // Reminder DeleteReminder(int reminderId);
    }
}

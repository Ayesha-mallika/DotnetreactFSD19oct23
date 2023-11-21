using EventCalendarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventCalendarApp.Contexts
{
    public class CalendarContext : DbContext
    {
        public CalendarContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Reminder> Reminders { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relationship between Event and Category
            modelBuilder.Entity<Event>()
                .HasOne<Category>(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Event>(events =>
            {
                events.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Notification>(notification =>
            {
                notification.HasKey(n => n.Id);
            });
            modelBuilder.Entity<Reminder>(reminder =>
            {
                reminder.HasKey(r => r.Id);
            });
            
            /*modelBuilder.Entity<Notification>()
                .HasOne(n => n.Reminder)
                .WithMany(r => r.Notifications)
                .HasForeignKey(n => n.ReminderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.Email)
                .OnDelete(DeleteBehavior.Cascade);*/


        }
    }
}

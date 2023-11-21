using System.ComponentModel.DataAnnotations;

namespace EventCalendarApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string color { get; set; }

        public ICollection<Event>? Events { get; set; }

    }
}
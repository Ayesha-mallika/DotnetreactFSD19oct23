using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EventCalendarApp.Models.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace EventCalendarApp.Models
{
    public class Event
    {

        /// <summary>
        /// it is a model class for events
        /// </summary>
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime StartDateTime { get; set; } 
        public DateTime EndDateTime { get; set; }
        public string? Location { get; set; }
        public bool? IsRecurring { get; set; }
        
        // Foreign Key for Category

        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "Each event should have single category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


       /* [ForeignKey("UserEmail")]
        public string UserEmail { get; set; }
        public UserDTO? User { get; set; }

        //one-to-one relationship
        //public Reminder? Reminder { get; set; }*/

    }
    
}
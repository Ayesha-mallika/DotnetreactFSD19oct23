using System.ComponentModel.DataAnnotations;
using EventCalendarApp.Models.DTOs;

namespace EventCalendarApp.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Password { get; set; }
        public string? Role { get; set; }
        public byte[]? Key { get; set; }

       
    }
}
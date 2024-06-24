using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace FlightBooking.Server.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}

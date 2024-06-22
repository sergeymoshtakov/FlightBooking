using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Server.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public Guid FlightId { get; set; }
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
        [Required]
        public Guid SeatId { get; set; }
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public string Status { get; set; }
    }
}

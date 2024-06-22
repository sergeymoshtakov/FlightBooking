using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Server.Models
{
    public class Seat
    {
        public Guid SeatId { get; set; }
        [Required]
        public Guid AircraftId { get; set; }
        [Required]
        public string SeatNumber { get; set; }
        [Required]
        public string Class { get; set; }
        public Aircraft Aircraft { get; set; }
    }
}

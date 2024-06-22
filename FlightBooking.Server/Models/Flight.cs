using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace FlightBooking.Server.Models
{
    public class Flight
    {
        public Guid FlightId { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public Guid DepartureAirportId { get; set; }
        [ForeignKey("DepartureAirportId")]
        public Airport DepartureAirport { get; set; }
        [Required]
        public Guid ArrivalAirportId { get; set; }
        [ForeignKey("ArrivalAirportId")]
        public Airport ArrivalAirport { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public Guid AircraftId { get; set; }
        [ForeignKey("AircraftId")]
        public Aircraft Aircraft { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}

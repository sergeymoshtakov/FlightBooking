using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Server.Models
{
    public class Aircraft
    {
        public Guid AircraftId { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public int SeatingCapacity { get; set; }

        public ICollection<Seat> Seats { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}

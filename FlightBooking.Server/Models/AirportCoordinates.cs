using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Server.Models
{
    public class AirportCoordinates
    {
        public Guid AirportCoordinatesId { get; set; }
        [Required]
        public Guid AirportId { get; set; }
        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }
        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }
    }
}

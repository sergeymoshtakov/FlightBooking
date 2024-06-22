using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Server.Models
{
    public class Airport
    {
        public Guid AirportId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Code { get; set; }
    }
}

using FlightBooking.Server.Data;
using FlightBooking.Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DistanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("calculate")]
        public IActionResult CalculateDistance(Guid departureAirportId, Guid arrivalAirportId)
        {
            var departureAirport = _context.Airports
                .Where(a => a.AirportId == departureAirportId)
                .Select(a => a.Coordinates)
                .FirstOrDefault();

            var arrivalAirport = _context.Airports
                .Where(a => a.AirportId == arrivalAirportId)
                .Select(a => a.Coordinates)
                .FirstOrDefault();

            if (departureAirport == null || arrivalAirport == null)
            {
                return NotFound("One or both airports not found.");
            }

            double distance = DistanceCalculator.CalculateDistance(
                departureAirport.Latitude,
                departureAirport.Longitude,
                arrivalAirport.Latitude,
                arrivalAirport.Longitude
            );

            return Ok(new { Distance = distance });
        }
    }
}

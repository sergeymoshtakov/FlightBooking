namespace FlightBooking.Server.Models
{
    public class UserSession
    {
        public Guid UserId { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}

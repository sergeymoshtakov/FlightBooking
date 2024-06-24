using FlightBooking.Server.Models;

namespace FlightBooking.Server.Services
{
    public interface IUserSessionService
    {
        void SetUserSession(UserSession session);
        UserSession GetUserSession(Guid userId);
        void ClearUserSession(Guid userId);
    }
}

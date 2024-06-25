using System.Runtime.InteropServices;

namespace FlightBooking.Server.Helpers
{
    public class DistanceCalculator
    {
        [DllImport("DistanceCalculator.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
    }
}

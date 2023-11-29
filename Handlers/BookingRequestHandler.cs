using SettlementBookingSystemAPI.Models;
using System.Globalization;

namespace SettlementBookingSystemAPI.Handlers
{
    public class BookingRequestHandler
    {
        public string TimeChecking(string bookingTime)
        {
            string expiredTime = "";
            var bookingTimeParse = TimeOnly.Parse(bookingTime, CultureInfo.InvariantCulture);

            if (bookingTimeParse.Hour < 9 || bookingTimeParse.Hour > 16)
            {
                return "Fail!";
            }
            else
            {
                expiredTime = bookingTimeParse.AddHours(1).ToString();
                return expiredTime;
            }
        }
    }
}

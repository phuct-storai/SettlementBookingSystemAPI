using SettlementBookingSystemAPI.Models;
using System.Globalization;

namespace SettlementBookingSystemAPI.Handlers
{
    public class BookingRequestHandler
    {
        private const int OPENTIME = 9;
        private const int CLOSETIME = 16;

        public string TimeChecking(string bookingTime)
        {
            string expiredTime = "";
            var bookingTimeParse = Convert.ToDateTime(bookingTime);

            if (bookingTimeParse.Hour < OPENTIME || bookingTimeParse.Hour > CLOSETIME)
            {
                return "Fail!";
            }

            else
                return CreateExpiredTime(out expiredTime, bookingTimeParse);
        }

        private static string CreateExpiredTime(out string expiredTime, DateTime bookingTimeParse)
        {
            expiredTime = bookingTimeParse.AddHours(1).ToString();
            return expiredTime;
        }

        public bool TimeRangeChecking (string startTime, string endTime, string bookingTime)
        {
            var startTimeParse = Convert.ToDateTime(startTime);
            var endTimeParse = Convert.ToDateTime(endTime);
            var bookingTimeParse = Convert.ToDateTime(bookingTime);
            if (bookingTimeParse >  startTimeParse && bookingTimeParse < endTimeParse)
            {
                return false;
            }
            return true;
        }
    }
}

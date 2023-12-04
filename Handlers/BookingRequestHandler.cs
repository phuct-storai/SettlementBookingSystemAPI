using Microsoft.AspNetCore.Mvc;
using SettlementBookingSystemAPI.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SettlementBookingSystemAPI.Handlers
{
    public class BookingRequestHandler
    {
        public bool TimeChecking(string bookingTime)
        {
            Regex timeRegex = new Regex("^(0[9]|1[0-5]):[0-5][0-9]:[0-5][0-9]$");
            if (!Regex.IsMatch(bookingTime, timeRegex.ToString()))
                return false;

            return true;
        }

        public bool ConflictBookingChecking (string startTime, string endTime, string bookingTime)
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

﻿using Microsoft.AspNetCore.Mvc;
using SettlementBookingSystemAPI.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SettlementBookingSystemAPI.Handlers
{
    public class BookingRequestHandler
    {
        private const int OPENTIME = 9;
        private const int CLOSETIME = 16;

        public bool TimeChecking(string bookingTime)
        {
            //string expiredTime = "";
            //var bookingTimeParse = Convert.ToDateTime(bookingTime);
            Regex timeRegex = new Regex("^(0[9]|1[0-6]):[0-5][0-9]:[0-5][0-9]$");

            //if (bookingTimeParse.Hour < OPENTIME || bookingTimeParse.Hour > CLOSETIME)
            if (!Regex.IsMatch(bookingTime, timeRegex.ToString()))
                return false;

            return true;
            //{
            //    return "Fail!";
            //}
            //else
            //    return CreateExpiredTime(out expiredTime, bookingTimeParse);
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

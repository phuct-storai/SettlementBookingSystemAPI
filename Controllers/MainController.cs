using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SettlementBookingSystemAPI.Handlers;
using SettlementBookingSystemAPI.Models;
using System;
using System.Net;
using System.Text.Json.Serialization;

namespace SettlementBookingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IMediator _mediator;
        private static List<BookingRequest> bookingRequestList = new List<BookingRequest>();


        public MainController(ILogger<MainController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("get-information")]
        public async Task<ActionResult<List<BookingRequest>>> GettAllBookingRequests()
        {
            return Ok(bookingRequestList);
        }

        [HttpPost("get-booking")]
        public async Task<ActionResult> GetBookingRequest([FromBody] BookingRequest bookingRequest)
        {
            BookingRequestHandler bookingRequestHandler = new BookingRequestHandler();

            if (bookingRequestList.Count < 4)
            {
                if (bookingRequestHandler.TimeChecking(bookingRequest.BookingTime).ToString() != "Fail!")
                {
                    if (bookingRequestHandler.SlotExitsChecking(bookingRequestList, bookingRequest.BookingTime))
                    {
                        var response = new BookingRequest
                        {
                            BookingId = Guid.NewGuid().ToString(),
                            Name = bookingRequest.Name,
                            BookingTime = DateTime.Parse(bookingRequest.BookingTime).ToString("HH:mm:ss"),
                            ExpiredTime = DateTime.Parse(bookingRequest.BookingTime).AddHours(1).ToString("HH:mm:ss"),
                        };

                        bookingRequestList.Add(response);
                        return Ok(response.BookingId);
                    }
                    else
                    {
                        return Conflict();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest();
        }
    }
}

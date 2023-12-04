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
            //Checking numbers of exits clients
            if (bookingRequestList.Count > 4)
            {
                return BadRequest();
            }
            else
            {
                //Checking valid time range to book
                if (!bookingRequestHandler.TimeChecking(bookingRequest.BookingTime))
                {
                    return BadRequest();
                }
                else
                {
                    for (int i = 0; i < bookingRequestList.Count; i++)
                    {
                        //Check conflict slot
                        if (!bookingRequestHandler.ConflictBookingChecking(bookingRequestList[i].BookingTime, bookingRequestList[i].ExpiredTime, bookingRequest.BookingTime))
                        {
                            return Conflict();
                        }
                    }
                    return AddToDoneBookingList(bookingRequest);
                }
            }
        }

        private ActionResult AddToDoneBookingList(BookingRequest bookingRequest)
        {
            var requestItem = new BookingRequest
            {
                BookingId = Guid.NewGuid().ToString(),
                Name = bookingRequest.Name,
                BookingTime = DateTime.Parse(bookingRequest.BookingTime).ToString("HH:mm:ss"),
                ExpiredTime = DateTime.Parse(bookingRequest.BookingTime).AddHours(1).ToString("HH:mm:ss"),
            };
            bookingRequestList.Add(requestItem);
            return Ok(requestItem.BookingId);
        }
    }
}

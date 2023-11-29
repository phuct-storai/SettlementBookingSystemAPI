using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SettlementBookingSystemAPI.Handlers;
using SettlementBookingSystemAPI.Models;
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

        public MainController(ILogger<MainController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("get-booking")]
        public async Task<IActionResult> GetBookingRequest([FromBody] BookingRequest bookingRequest)
        {
            BookingRequestHandler bookingRequestHandler = new BookingRequestHandler();

            if (bookingRequestHandler.TimeChecking(bookingRequest.BookingTime).ToString() != "Fail!")
            {
                var response = new BookingRequest
                {
                    BookingId = Guid.NewGuid().ToString(),
                    Name = bookingRequest.Name,
                    BookingTime = bookingRequest.BookingTime,
                    ExpiredTime = DateTime.Parse(bookingRequest.BookingTime).AddHours(1).ToString("HH:mm:ss"),
                };
                return Ok(response.BookingId);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

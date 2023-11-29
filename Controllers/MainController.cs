using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SettlementBookingSystemAPI.Models;
using System.Text.Json.Serialization;

namespace SettlementBookingSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        private readonly IMediator _mediator;
        private readonly string url = "https://localhost:44355";
        private readonly string url2 = "https://google.com";


        public MainController(ILogger<MainController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("get-booking")]
        public async Task<BookingRequestDto> GetBookingRequest([FromBody] BookingRequest bookingRequest)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            //    //var jsonObject = await httpResponseMessage.Content.ReadAsStringAsync();

            //    //var bookingRequest = JsonConvert.DeserializeObject<BookingRequest>(jsonObject);

            //    httpResponseMessage.EnsureSuccessStatusCode();
                
            //    var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            //    var bookingRequest = JsonConvert.DeserializeObject<BookingRequestDto>(responseString);

            //    return bookingRequest;
                
            //}

            if (bookingRequest.BookingTime.)
        }
    }
}

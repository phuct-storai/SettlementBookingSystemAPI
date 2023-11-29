namespace SettlementBookingSystemAPI.Models
{
    public class BookingRequestDto
    {
        public BookingRequestDto(Guid bookingRequestId)
        {
            bookingRequestId = new Guid();
        }
        public Guid bookingRequestId { get; set; }
    }
}

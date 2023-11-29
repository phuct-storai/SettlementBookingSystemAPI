namespace SettlementBookingSystemAPI.Models
{
    public class BookingRequest
    {
        public BookingRequest()
        {
            this.BookingTime = BookingTime;
            this.Name = Name;
        }
        public string BookingId { get; set; }
        public string Name { get; set; }
        public string BookingTime { get; set; }
        public string ExpiredTime { get; set; }



    }
}

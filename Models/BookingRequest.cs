namespace SettlementBookingSystemAPI.Models
{
    public class BookingRequest
    {
        public BookingRequest()
        {
            this.BookingTime = BookingTime;
            this.Name = Name;
        }

        public DateTime BookingTime { get; set; }

        public string Name { get; set; }
    }
}

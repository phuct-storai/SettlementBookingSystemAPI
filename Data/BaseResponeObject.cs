namespace SettlementBookingSystemAPI.Data
{
    public class BaseResponseObject
    {
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// The ResponseCode.
        /// </summary>
        public string ResponseCode { get; set; }

        /// <summary>
        /// The ResponseMessage.
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// The StackTrace.
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// The Data.
        /// </summary>
        public object Data { get; set; }
    }
}

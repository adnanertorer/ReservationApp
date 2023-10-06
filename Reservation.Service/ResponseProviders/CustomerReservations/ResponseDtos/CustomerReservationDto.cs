namespace Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos
{
    public class CustomerReservationDto
    {
        public long Id { get; set; }
        public long TableId { get; set; }
        public string TableName { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public short GuestCount { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}

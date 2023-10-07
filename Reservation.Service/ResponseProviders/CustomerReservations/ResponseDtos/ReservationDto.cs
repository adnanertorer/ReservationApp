namespace Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos
{
    public class ReservationDto
    {
        public long Id { get; set; }
        public long TableId { get; set; }
        public long CustomerId { get; set; }
        public short GuestCount { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
    }
}

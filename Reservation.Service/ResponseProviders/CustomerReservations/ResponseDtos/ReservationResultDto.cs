namespace Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos
{
    public class ReservationResultDto
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string TableName { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public int GuestCount { get; set; }
    }
}

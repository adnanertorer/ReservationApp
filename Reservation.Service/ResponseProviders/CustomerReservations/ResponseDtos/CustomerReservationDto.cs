using Reservation.Service.ResponseProviders.Customers.ResponseDtos;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos
{
    public class CustomerReservationDto
    {
        public CustomerDto CustomerDto { get; set; }
        public TableDto TableDto { get; set; }
        public short GuestCount { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }


    }
}

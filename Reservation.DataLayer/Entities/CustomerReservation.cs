﻿using IsSystem.Core.Repositories;

namespace Reservation.DataLayer.Entities
{
    public class CustomerReservation:Entity<long>
    {
        public long TableId { get; set; }
        public long CustomerId { get; set; }
        public short GuestCount { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }

        public Table? Table { get; set; }
        public Customer? Customer { get; set; }
    }
}

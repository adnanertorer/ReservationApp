using IsSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Reservation.DataLayer.Enums;

namespace Reservation.DataLayer.Entities
{
    public class Table:Entity<long>
    {
        public required string TableName { get; set; }
        public int Capacity { get; set; }
        public short Status { get; set; }

        public virtual ICollection<CustomerReservation>? CustomerReservations { get; set; }

    }
}

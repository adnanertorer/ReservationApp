using IsSystem.Core.Repositories;

namespace Reservation.DataLayer.Entities
{
    public class Table:Entity<long>
    {
        public required string TableName { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<CustomerReservation>? CustomerReservations { get; set; }

    }
}

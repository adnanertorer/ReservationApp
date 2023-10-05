using IsSystem.Core.Repositories;

namespace Reservation.DataLayer.Entities
{
    public class Customer:Entity<long>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public virtual ICollection<CustomerReservation>? CustomerReservations { get; set; }
    }
}

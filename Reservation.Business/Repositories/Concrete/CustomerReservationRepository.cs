using IsSystem.Core.Repositories;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer;
using Reservation.DataLayer.Entities;

namespace Reservation.Business.Repositories.Concrete
{
    public class CustomerReservationRepository : EfRepositoryBase<CustomerReservation, long, ReservationDbContext>, ICustomerReservationRepository
    {
        public CustomerReservationRepository(ReservationDbContext context) : base(context)
        {
        }
    }
}

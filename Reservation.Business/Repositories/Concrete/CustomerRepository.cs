using IsSystem.Core.Repositories;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer;
using Reservation.DataLayer.Entities;

namespace Reservation.Business.Repositories.Concrete
{
    public class CustomerRepository : EfRepositoryBase<Customer, long, ReservationDbContext>, ICustomerRepository
    {
        public CustomerRepository(ReservationDbContext context) : base(context)
        {
        }
    }
}

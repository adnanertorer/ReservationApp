using IsSystem.Core.Repositories;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer;
using Reservation.DataLayer.Entities;

namespace Reservation.Business.Repositories.Concrete
{
    public class TableRepository : EfRepositoryBase<Table, long, ReservationDbContext>, ITableRepository
    {
        public TableRepository(ReservationDbContext context) : base(context)
        {
        }
    }
}

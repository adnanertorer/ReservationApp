using IsSystem.Core.Repositories;
using Reservation.DataLayer.Entities;

namespace Reservation.Business.Repositories.Abstracts
{
    public interface ITableRepository : IAsyncRepository<Table, long>
    {
    }
}

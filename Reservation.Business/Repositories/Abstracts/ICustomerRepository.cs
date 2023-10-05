using IsSystem.Core.Repositories;
using Reservation.DataLayer.Entities;

namespace Reservation.Business.Repositories.Abstracts
{
    public interface ICustomerRepository : IAsyncRepository<Customer, long>
    {
    }
}

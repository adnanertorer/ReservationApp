using IsSystem.Application.Rules;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Rules
{
    public class CheckCustomerExistRule: BaseBusinessRule
    {
        private readonly ICustomerRepository _customerRepository;

        public CheckCustomerExistRule(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> CheckCustomerExist(CustomerDto customerDto)
        {
            Customer? result = await _customerRepository.GetAsync(predicate: b => b.Email == customerDto.Email || b.Phone == customerDto.Phone);
            return result;
        }
    }
}

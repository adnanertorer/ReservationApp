using IsSystem.Application.Exceptions;
using IsSystem.Application.Rules;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Customers.Constants;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Customers.Rules
{
    public class UnicCustomerRule: BaseBusinessRule
    {
        private readonly ICustomerRepository _repository;

        public UnicCustomerRule()
        {
            
        }

        public UnicCustomerRule(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task CustomerMustBeUnic(CustomerDto customer)
        {
            Customer? result = await _repository.GetAsync(predicate: b => b.Email == customer.Email || b.Phone == customer.Phone);

            if (result != null)
            {
                throw new BusinessException(CustomerMessages.CustomerExists);
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;
using Reservation.Service.ResponseProviders.Customers.Rules;

namespace Reservation.Service.ResponseProviders.Customers.Commands.Create
{
    public class CreateCustomerCommand:IRequest<CustomerDto>
    {
        public CustomerDto Customer { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;
            private readonly UnicCustomerRule _unicCustomerRule;

            public CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper, UnicCustomerRule unicCustomerRule)
            {
                _repository = repository;
                _mapper = mapper;
                _unicCustomerRule = unicCustomerRule;
            }

            public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _unicCustomerRule.CustomerMustBeUnic(request.Customer);

                var model = await _repository.AddAsync(_mapper.Map<Customer>(request.Customer));
                return _mapper.Map<CustomerDto>(model);
            }
        }

    }
}

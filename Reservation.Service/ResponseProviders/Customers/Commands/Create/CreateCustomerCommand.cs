using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Customers.Commands.Create
{
    public class CreateCustomerCommand:IRequest<CustomerDto>
    {
        public CustomerDto Customer { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var model = await _repository.AddAsync(_mapper.Map<Customer>(request.Customer));
                return _mapper.Map<CustomerDto>(model);
            }
        }

    }
}

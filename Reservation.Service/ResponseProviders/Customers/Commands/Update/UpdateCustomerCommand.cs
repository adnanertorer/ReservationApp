using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Customers.Commands.Update
{
    public class UpdateCustomerCommand: IRequest<CustomerDto>
    {
        public CustomerDto Customer { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var model = await _repository.GetAsync(i => i.Id == request.Customer.Id, cancellationToken: cancellationToken);
                model = _mapper.Map(request.Customer, model);
                await _repository.UpdateAsync(model);
                return _mapper.Map<CustomerDto>(model);
            }
        }
    }
}

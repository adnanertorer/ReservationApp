using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Customers.Queries.GetById
{
    public class GetCustomerQuery:IRequest<CustomerDto>
    {
        public long Id { get; set; }

        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;

            public GetCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
               var customer = await _repository.GetAsync(predicate: p=>p.Id == request.Id);
               return _mapper.Map<CustomerDto>(customer);
            }
        }
    }
}

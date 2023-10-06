using AutoMapper;
using IsSystem.Application.Requests;
using IsSystem.Application.Responses;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Customers.Queries.GetList
{
    public class GetListCustomerQuery:IRequest<GetListResponse<CustomerDto>>
    {
        public required PageRequest PageRequest { get; set; }

        public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, GetListResponse<CustomerDto>>
        {
            private readonly ICustomerRepository _repository;
            private readonly IMapper _mapper;

            public GetListCustomerQueryHandler(ICustomerRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<GetListResponse<CustomerDto>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
            {
                var customers = await _repository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);
                return _mapper.Map<GetListResponse<CustomerDto>>(customers);
            }
        }
    }
}

using AutoMapper;
using IsSystem.Application.Requests;
using IsSystem.Application.Responses;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Queries.GetList
{
    public class GetCustomerReservationListQuery: IRequest<GetListResponse<CustomerReservationDto>>
    {
        public required PageRequest PageRequest { get; set; }

        public class GetCustomerReservationListQueryHandler : IRequestHandler<GetCustomerReservationListQuery, GetListResponse<CustomerReservationDto>>
        {
            private readonly ICustomerReservationRepository _repository;
            private readonly IMapper _mapper;

            public GetCustomerReservationListQueryHandler(ICustomerReservationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<GetListResponse<CustomerReservationDto>> Handle(GetCustomerReservationListQuery request, CancellationToken cancellationToken)
            {
                var reservations = await _repository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);
                return _mapper.Map<GetListResponse<CustomerReservationDto>>(reservations);
            }
        }
    }
}

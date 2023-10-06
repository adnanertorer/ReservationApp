using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Queries.GetById
{
    public class GetCustomerReservationQuery: IRequest<CustomerReservationDto>
    {
        public required long Id { get; set; }

        public class GetCustomerReservationHandler : IRequestHandler<GetCustomerReservationQuery, CustomerReservationDto>
        {
            private readonly ICustomerReservationRepository _repository;
            private readonly IMapper _mapper;

            public GetCustomerReservationHandler(ICustomerReservationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<CustomerReservationDto> Handle(GetCustomerReservationQuery request, CancellationToken cancellationToken)
            {
                var reservation = await _repository.GetAsync(predicate: p => p.Id == request.Id);
                return _mapper.Map<CustomerReservationDto>(reservation);
            }
        }
    }
}

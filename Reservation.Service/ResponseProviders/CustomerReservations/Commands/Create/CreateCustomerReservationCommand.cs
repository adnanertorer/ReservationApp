using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create
{
    public class CreateCustomerReservationCommand: IRequest<CustomerReservationDto>
    {
        public required CustomerReservationDto CustomerReservation { get; set; }

        public class CreateCustomerReservationCommandHandler : IRequestHandler<CreateCustomerReservationCommand, CustomerReservationDto>
        {
            private readonly ICustomerReservationRepository _repository;
            private readonly IMapper _mapper;

            public CreateCustomerReservationCommandHandler(ICustomerReservationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<CustomerReservationDto> Handle(CreateCustomerReservationCommand request, CancellationToken cancellationToken)
            {
                var model = await _repository.AddAsync(_mapper.Map<CustomerReservation>(request.CustomerReservation));
                return _mapper.Map<CustomerReservationDto>(model);
            }
        }
    }
}

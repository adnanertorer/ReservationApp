using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Commands.Update
{
    public class UpdateCustomerReservationCommand : IRequest<CustomerReservationDto>
    {
        public required CustomerReservationDto CustomerReservation { get; set; }

        public class UpdateCustomerReservationCommandHandler : IRequestHandler<UpdateCustomerReservationCommand, CustomerReservationDto>
        {
            private readonly ICustomerReservationRepository _repository;
            private readonly IMapper _mapper;

            public UpdateCustomerReservationCommandHandler(ICustomerReservationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CustomerReservationDto> Handle(UpdateCustomerReservationCommand request, CancellationToken cancellationToken)
            {
                var model = await _repository.GetAsync(i => i.Id == request.CustomerReservation.Id, cancellationToken: cancellationToken);
                model = _mapper.Map(request.CustomerReservation, model);
                await _repository.UpdateAsync(model);
                return _mapper.Map<CustomerReservationDto>(model);
            }
        }
    }
}

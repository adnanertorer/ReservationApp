using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;
using Reservation.Service.ResponseProviders.CustomerReservations.Rules;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create
{
    public class CreateCustomerReservationCommand: IRequest<CustomerReservationDto>
    {
        public required CustomerReservationDto CustomerReservation { get; set; }

        public class CreateCustomerReservationCommandHandler : IRequestHandler<CreateCustomerReservationCommand, CustomerReservationDto>
        {
            private readonly ICustomerReservationRepository _repository;
            private readonly IMapper _mapper;
            private readonly TableAvailableRule _tableAvailableRule;
            private readonly ICustomerRepository _customerRepository;
            private readonly ITableRepository _tableRepository;

            public CreateCustomerReservationCommandHandler(ICustomerReservationRepository repository, IMapper mapper, 
                TableAvailableRule tableAvailableRule, ICustomerRepository customerRepository, ITableRepository tableRepository)
            {
                _repository = repository;
                _mapper = mapper;
                _tableAvailableRule = tableAvailableRule;
                _customerRepository = customerRepository;
                _tableRepository = tableRepository;
            }
            public async Task<CustomerReservationDto> Handle(CreateCustomerReservationCommand request, CancellationToken cancellationToken)
            {
                await _tableAvailableRule.TableMustBeAvailable(request.CustomerReservation);

                var customer = await _customerRepository.AddAsync(_mapper.Map<Customer>(request.CustomerReservation.CustomerDto));


                var reservation = new CustomerReservation()
                {
                    CreatedAt = DateTime.UtcNow,
                    CustomerId = customer.Id,
                    GuestCount = request.CustomerReservation.GuestCount,
                    ReservationStartDate = request.CustomerReservation.ReservationStartDate,
                    ReservationEndDate = request.CustomerReservation.ReservationEndDate,
                    TableId = request.CustomerReservation.TableDto.Id
                };

                var model = await _repository.AddAsync(_mapper.Map<CustomerReservation>(reservation));

                return _mapper.Map<CustomerReservationDto>(model);
            }
        }
    }
}

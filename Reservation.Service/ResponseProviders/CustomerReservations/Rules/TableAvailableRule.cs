using IsSystem.Application.Exceptions.Types;
using IsSystem.Application.Rules;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.CustomerReservations.Constants;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Rules
{
    public class TableAvailableRule: BaseBusinessRule
    {
        private readonly ICustomerReservationRepository _repository;

        public TableAvailableRule(ICustomerReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task TableMustBeAvailable(CustomerReservationDto reservationDto)
        {
            var reservations = await _repository.AnyAsync(predicate: r => (r.ReservationStartDate <= reservationDto.ReservationStartDate
            && r.ReservationEndDate >= reservationDto.ReservationStartDate) || (r.ReservationStartDate <= reservationDto.ReservationEndDate
            && r.ReservationEndDate >= reservationDto.ReservationEndDate));
            if (reservations)
            {
                throw new BusinessException(ReservationMessages.TableIsNotAvailable);
            }
        }
    }
}

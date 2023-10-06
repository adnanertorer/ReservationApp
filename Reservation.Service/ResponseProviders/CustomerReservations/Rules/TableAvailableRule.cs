using IsSystem.Application.Exceptions;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Enums;
using Reservation.Service.ResponseProviders.CustomerReservations.Constants;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Rules
{
    public class TableAvailableRule
    {
        private readonly ICustomerReservationRepository _repository;

        public TableAvailableRule(ICustomerReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task TableMustBeAvailable(CustomerReservationDto reservationDto)
        {
            var result = await _repository.GetAsync(predicate: b => b.Id == reservationDto.TableId &&
            (b.Table!.Status == (short)TableStatusEnum.Availabe || b.ReservationDate.AddHours(6) <= reservationDto.ReservationDate));

            if (result == null)
            {
                throw new BusinessException(ReservationMessages.TableIsNotAvailable);
            }
        }
    }
}

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
            var reservations = await _repository.AnyAsync(predicate: r => r.TableId == reservationDto.TableDto.Id &&
            (r.ReservationStartDate <= reservationDto.ReservationStartDate
            && r.ReservationEndDate >= reservationDto.ReservationStartDate) || (r.ReservationStartDate <= reservationDto.ReservationEndDate
            && r.ReservationEndDate >= reservationDto.ReservationEndDate)); // verilen zamanlar arasında secilen masa dolu mu?
            if (reservations)
            {
                throw new BusinessException(ReservationMessages.TableIsNotAvailable); // dolu ise durum mesaji firlat
            }
            else
            {
                if(reservationDto.GuestCount > reservationDto.TableDto.Capacity) // dolu degil ise masa kapasitesi ile kisi sayini kontrol et
                {
                    // kisi sayisi masa kapasitesinden buyukse durum mesaji firlat
                    throw new BusinessException(String.Format(ReservationMessages.TableCapacityNotAvailable, reservationDto.TableDto.Capacity, reservationDto.GuestCount));
                }
            }
        }
    }
}

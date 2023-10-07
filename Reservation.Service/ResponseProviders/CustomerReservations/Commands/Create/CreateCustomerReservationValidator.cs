using FluentValidation;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create
{
    public class CreateCustomerReservationValidator : AbstractValidator<CreateCustomerReservationCommand>
    {
        public CreateCustomerReservationValidator()
        {
            RuleFor(c => c.CustomerReservation.CustomerDto.Name).NotEmpty();
            RuleFor(c => c.CustomerReservation.CustomerDto.Surname).NotEmpty();
            RuleFor(c => c.CustomerReservation.CustomerDto.Phone).NotEmpty();
            RuleFor(c => c.CustomerReservation.CustomerDto.Email).NotEmpty();
            RuleFor(c=>c.CustomerReservation.ReservationStartDate).NotNull();
            RuleFor(c => c.CustomerReservation.ReservationEndDate).NotNull();
            RuleFor(c=>c.CustomerReservation.TableDto).NotNull();
            RuleFor(c=>c.CustomerReservation.GuestCount).NotNull();
        }
    }
}

using FluentValidation;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create
{
    public class CreateCustomerReservationValidator : AbstractValidator<CreateCustomerReservationCommand>
    {
        public CreateCustomerReservationValidator()
        {
            RuleFor(c=>c.CustomerReservation.CustomerName).NotEmpty();
            RuleFor(c=>c.CustomerReservation.ReservationDate).NotNull();
            RuleFor(c=>c.CustomerReservation.CustomerId).NotNull();
            RuleFor(c=>c.CustomerReservation.GuestCount).NotNull();

        }
    }
}

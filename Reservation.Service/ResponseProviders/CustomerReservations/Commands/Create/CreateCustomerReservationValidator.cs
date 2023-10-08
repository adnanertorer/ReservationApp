using FluentValidation;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create
{
    public class CreateCustomerReservationValidator : AbstractValidator<CreateCustomerReservationCommand>
    {
        public CreateCustomerReservationValidator()
        {
            RuleFor(c => c.CustomerReservation.CustomerDto.Name).NotEmpty().WithMessage("Ad alanı boş olamaz");
            RuleFor(c => c.CustomerReservation.CustomerDto.Surname).NotEmpty().WithMessage("Soyad alanı boş olamaz");
            RuleFor(c => c.CustomerReservation.CustomerDto.Phone).NotEmpty().WithMessage("Telefon alanı boş olamaz");
            RuleFor(c => c.CustomerReservation.CustomerDto.Email).NotEmpty().WithMessage("Email alanı boş olamaz");
            RuleFor(c=>c.CustomerReservation.ReservationStartDate).Must(mustBeValidDate).WithMessage("Lütfen başlangıç zamanı belirtiniz")
                .GreaterThan(DateTime.Now).WithMessage("Geçmiş tarihe reservasyon yapılamaz");
            RuleFor(c => c.CustomerReservation.ReservationEndDate).Must(mustBeValidDate).WithMessage("Lütfen bitiş zamanı belirtiniz")
                .GreaterThan(c=>c.CustomerReservation.ReservationStartDate).WithMessage("Bitiş tarihi başlangıç tarihinden büyük olmalıdır");
            RuleFor(c=>c.CustomerReservation.TableDto.Id).NotEqual(0).WithMessage("Lütfen bir masa seçiniz");
            RuleFor(c => c.CustomerReservation.GuestCount).NotNull();
        }

        private bool mustBeValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

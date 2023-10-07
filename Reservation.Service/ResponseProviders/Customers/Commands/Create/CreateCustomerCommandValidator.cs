using FluentValidation;

namespace Reservation.Service.ResponseProviders.Customers.Commands.Create
{
    public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c=>c.Customer.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(c => c.Customer.Surname).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(c => c.Customer.Email).NotEmpty().MinimumLength(8).MaximumLength(50);
            RuleFor(c => c.Customer.Phone).NotEmpty().MinimumLength(10).MaximumLength(20);
        }
    }
}

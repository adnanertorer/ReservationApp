using FluentValidation;

namespace Reservation.Service.ResponseProviders.Tables.Commands.Create
{
    public class CreateTableCommandValidator: AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(t=>t.Table.TableName).NotEmpty().MinimumLength(1);
            RuleFor(t => t.Table.Capacity).NotEmpty();
        }
    }
}

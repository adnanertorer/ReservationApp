using IsSystem.Application.Exceptions.Types;
using IsSystem.Application.Rules;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Tables.Constants;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Tables.Rules
{
    public class UnicTableRule: BaseBusinessRule
    {
        private readonly ITableRepository _repository;

        public UnicTableRule(ITableRepository repository)
        {
            _repository = repository;
        }

        public async Task TableMustBeUnic(TableDto table)
        {
            Table? result = await _repository.GetAsync(predicate: b => b.TableName.ToLower() == table.TableName.ToLower());

            if (result != null)
            {
                throw new BusinessException(TableMessages.TableExists);
            }
        }
    }
}

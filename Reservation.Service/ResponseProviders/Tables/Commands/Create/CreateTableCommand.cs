using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;
using Reservation.Service.ResponseProviders.Tables.Rules;

namespace Reservation.Service.ResponseProviders.Tables.Commands.Create
{
    public class CreateTableCommand: IRequest<TableDto>
    {
        public required TableDto Table { get; set; }

        public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, TableDto>
        {
            private readonly ITableRepository _repository;
            private readonly IMapper _mapper;
            private readonly UnicTableRule _unicTableRule;

            public CreateTableCommandHandler(ITableRepository repository, IMapper mapper, UnicTableRule unicTableRule)
            {
                _repository = repository;
                _mapper = mapper;
                _unicTableRule = unicTableRule;
            }
            public async Task<TableDto> Handle(CreateTableCommand request, CancellationToken cancellationToken)
            {
                await _unicTableRule.TableMustBeUnic(request.Table);

                var model = await _repository.AddAsync(_mapper.Map<Table>(request.Table));
                return _mapper.Map<TableDto>(model);
            }
        }
    }
}

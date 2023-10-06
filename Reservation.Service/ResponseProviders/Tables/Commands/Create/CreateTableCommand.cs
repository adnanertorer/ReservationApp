using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Tables.Commands.Create
{
    public class CreateTableCommand: IRequest<TableDto>
    {
        public required TableDto Table { get; set; }

        public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, TableDto>
        {
            private readonly ITableRepository _repository;
            private readonly IMapper _mapper;

            public CreateTableCommandHandler(ITableRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<TableDto> Handle(CreateTableCommand request, CancellationToken cancellationToken)
            {
                var model = await _repository.AddAsync(_mapper.Map<Table>(request.Table));
                return _mapper.Map<TableDto>(model);
            }
        }
    }
}

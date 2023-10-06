using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Tables.Commands.Update
{
    public class UpdateTableCommand: IRequest<TableDto>
    {
        public required TableDto Table { get; set; }

        public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, TableDto>
        {
            private readonly ITableRepository _repository;
            private readonly IMapper _mapper;

            public UpdateTableCommandHandler(ITableRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<TableDto> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
            {
                var model = await _repository.GetAsync(i => i.Id == request.Table.Id, cancellationToken: cancellationToken);
                model = _mapper.Map(request.Table, model);
                await _repository.UpdateAsync(model);
                return _mapper.Map<TableDto>(model);
            }
        }
    }
}

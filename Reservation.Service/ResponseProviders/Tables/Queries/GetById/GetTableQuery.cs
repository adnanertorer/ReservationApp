using AutoMapper;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Tables.Queries.GetById
{
    public class GetTableQuery: IRequest<TableDto>
    {
        public required long Id { get; set; }

        public class GetTableQueryHandler : IRequestHandler<GetTableQuery, TableDto>
        {
            private readonly ITableRepository _repository;
            private readonly IMapper _mapper;

            public GetTableQueryHandler(ITableRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<TableDto> Handle(GetTableQuery request, CancellationToken cancellationToken)
            {
                var table = await _repository.GetAsync(predicate: p => p.Id == request.Id);
                return _mapper.Map<TableDto>(table);
            }
        }
    }
}

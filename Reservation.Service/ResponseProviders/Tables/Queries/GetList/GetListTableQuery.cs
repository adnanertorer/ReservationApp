using AutoMapper;
using IsSystem.Application.Requests;
using IsSystem.Application.Responses;
using MediatR;
using Reservation.Business.Repositories.Abstracts;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Tables.Queries.GetList
{
    public class GetListTableQuery : IRequest<GetListResponse<TableDto>>
    {
        public required PageRequest PageRequest { get; set; }

        public class GetListTableQueryHandler : IRequestHandler<GetListTableQuery, GetListResponse<TableDto>>
        {
            private readonly ITableRepository _repository;
            private readonly IMapper _mapper;

            public GetListTableQueryHandler(ITableRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<GetListResponse<TableDto>> Handle(GetListTableQuery request, CancellationToken cancellationToken)
            {
                var tables = await _repository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);
                return _mapper.Map<GetListResponse<TableDto>>(tables);
            }
        }
    }
}

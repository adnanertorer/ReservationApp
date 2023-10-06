using AutoMapper;
using IsSystem.Application.Responses;
using IsSystem.Core.Paging;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Tables.Commands.Create;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Tables.Profiles
{
    public class TableMappingProfile: Profile
    {
        public TableMappingProfile()
        {
            CreateMap<TableDto, Table>().ReverseMap();
            CreateMap<TableDto, CreateTableCommand>().ReverseMap();
            CreateMap<Paginate<Table>, GetListResponse<TableDto>>().ReverseMap();
        }
    }
}

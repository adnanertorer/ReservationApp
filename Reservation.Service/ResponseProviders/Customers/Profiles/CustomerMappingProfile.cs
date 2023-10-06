using AutoMapper;
using IsSystem.Application.Responses;
using IsSystem.Core.Paging;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.Customers.Commands.Create;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;

namespace Reservation.Service.ResponseProviders.Customers.Profiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerDto, CreateCustomerCommand>().ReverseMap();
            CreateMap<Paginate<Customer>, GetListResponse<CustomerDto>>().ReverseMap();
        }
    }
}

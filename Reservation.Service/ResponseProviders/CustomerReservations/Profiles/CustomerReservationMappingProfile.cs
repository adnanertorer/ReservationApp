using AutoMapper;
using IsSystem.Application.Responses;
using IsSystem.Core.Paging;
using Reservation.DataLayer.Entities;
using Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create;
using Reservation.Service.ResponseProviders.CustomerReservations.Commands.Update;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;

namespace Reservation.Service.ResponseProviders.CustomerReservations.Profiles
{
    public class CustomerReservationMappingProfile: Profile
    {
        public CustomerReservationMappingProfile()
        {
            CreateMap<CustomerReservationDto, CustomerReservation>().ReverseMap();
            CreateMap<CustomerReservationDto, CreateCustomerReservationCommand>().ReverseMap();
            CreateMap<CustomerReservationDto, UpdateCustomerReservationCommand>().ReverseMap();
            CreateMap<Paginate<CustomerReservation>, GetListResponse<CustomerReservationDto>>().ReverseMap();
        }
    }
}

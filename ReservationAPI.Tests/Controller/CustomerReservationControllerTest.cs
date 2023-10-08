using System.Net;
using Reservation.Service.ResponseProviders.CustomerReservations.Commands.Create;
using Reservation.Service.ResponseProviders.CustomerReservations.ResponseDtos;
using Reservation.Service.ResponseProviders.Customers.Commands.Create;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;
using ReservationAPI.Tests.Helpers;

namespace ReservationAPI.Tests.Controller;

public class CustomerReservationControllerTest
{
    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7221/api/") };
    
    [Fact]
    public async Task GetReservations_withPageParameters_ThenReturnsOk()
    {
        //Arrange
        var expectedStatusCode = System.Net.HttpStatusCode.OK;
        // Act.
        var response = await _httpClient.GetAsync("customerReservations/?PageIndex=0&PageSize=10");

        // Assert.
        Assert.True(response.StatusCode == expectedStatusCode);

    }
    
    [Fact]
    public async Task AddReservation_WithModel_ThenReturnsOk()
    {
        //Arrange
        const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;

        var reservation = new CustomerReservationDto()
        {
            CustomerDto = new CustomerDto()
            {
                Email = "mezeki@gmail.com",
                Name = "Mehmet Zeki",
                Phone = "5334025879",
                Surname = "Aydın"
            },
            GuestCount = 2,
            TableDto = new TableDto()
            {
                Capacity = 2,
                Id = 1,
                TableName = "A1"
            },
            ReservationStartDate = DateTime.Parse("2023-10-08 20:30"),
            ReservationEndDate = DateTime.Parse("2023-10-08 22:30")
        };

        var createCommand = new CreateCustomerReservationCommand()
        {
           CustomerReservation = reservation
        };

        // Act.
        var response = await _httpClient.PostAsync("customerReservations", JsonHelper.GetJsonStringContent<CreateCustomerReservationCommand>(createCommand));

        // Assert.
        Assert.True(response.StatusCode == expectedStatusCode);

    }
}
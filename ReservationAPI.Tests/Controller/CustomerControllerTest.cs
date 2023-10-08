using System.Net;
using Reservation.Service.ResponseProviders.Customers.Commands.Create;
using Reservation.Service.ResponseProviders.Customers.Commands.Update;
using Reservation.Service.ResponseProviders.Customers.ResponseDtos;
using ReservationAPI.Tests.Helpers;

namespace ReservationAPI.Tests.Controller
{
    public class CustomerControllerTest
    {
        private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7221/api/") };
        
        [Fact]
        public async Task GetCustomers_withPageParameters_ThenReturnsOk()
        {
            //Arrange
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            // Act.
            var response = await _httpClient.GetAsync("customers/?PageIndex=0&PageSize=10");

            // Assert.
            Assert.True(response.StatusCode == expectedStatusCode);

        }
        
        [Fact]
        public async Task AddCustomer_WithModel_ThenReturnsOk()
        {
            //Arrange
            const HttpStatusCode expectedStatusCode = System.Net.HttpStatusCode.OK;

            var customer = new CustomerDto()
            {
                Email = "test@test.com",
                Name = "Test Name",
                Surname = "Test Surname",
                Phone = "Test Phone"
            };

            var createCommand = new CreateCustomerCommand()
            {
                Customer = customer
            };

            // Act.
            var response = await _httpClient.PostAsync("customers", JsonHelper.GetJsonStringContent<CreateCustomerCommand>(createCommand));

            // Assert.
            Assert.True(response.StatusCode == expectedStatusCode);

        }
        
        [Fact]
        public async Task AddDuplicateCustomer_WithModel_ThenReturnsBadRequest()
        {
            //Arrange
            const HttpStatusCode expectedStatusCode = HttpStatusCode.BadRequest;

            var customer = new CustomerDto()
            {
                Email = "test@test.com",
                Name = "Test Name",
                Surname = "Test Surname",
                Phone = "Test Phone"
            };

            var createCommand = new CreateCustomerCommand()
            {
                Customer = customer
            };

            // Act.
            var response = await _httpClient.PostAsync("customers", JsonHelper.GetJsonStringContent<CreateCustomerCommand>(createCommand));

            // Assert.
            Assert.True(response.StatusCode == expectedStatusCode);

        }
        
        [Fact]
        public async Task UpdateCustomer_WithModel_ThenReturnsOk()
        {
            //Arrange
            const HttpStatusCode expectedStatusCode = System.Net.HttpStatusCode.OK;

            var customer = new CustomerDto()
            {
                Id = 4,
                Email = "adnanertorer@gmail.com",
                Name = "Adnan Kemal",
                Surname = "Ertörer",
                Phone = "5334025845"
            };

            var updateCommand = new UpdateCustomerCommand()
            {
                Customer = customer
            };

            // Act.
            var response = await _httpClient.PutAsync("customers", JsonHelper.GetJsonStringContent<UpdateCustomerCommand>(updateCommand));

            // Assert.
            Assert.True(response.StatusCode == expectedStatusCode);

        }
    }
}

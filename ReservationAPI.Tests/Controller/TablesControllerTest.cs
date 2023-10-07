using FakeItEasy;
using Reservation.Service.ResponseProviders.Tables.Commands.Create;
using Reservation.Service.ResponseProviders.Tables.Commands.Update;
using Reservation.Service.ResponseProviders.Tables.ResponseDtos;
using ReservationAPI.Tests.Helpers;

namespace ReservationAPI.Tests.Controller
{
    public class TablesControllerTest : IDisposable
    {
        private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("https://localhost:7221/api/") };

        [Fact]
        public async Task GetTables_withPageParameters_ThenReturnsOk()
        {
            //Arrange
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            // Act.
            var response = await _httpClient.GetAsync("tables/?PageIndex=0&PageSize=10");

            // Assert.
            Assert.True(response.StatusCode == expectedStatusCode);

        }

        [Fact]
        public async Task AddTable_WithModel_ThenReturnsOk()
        {
            //Arrange
            var expectedStatusCode = System.Net.HttpStatusCode.OK;

            var expectedContent = new TableDto
            {
                Capacity = 6,
                TableName = "D2",
            };

            var createCommand = new CreateTableCommand()
            {
                Table = expectedContent
            };

            // Act.
            var response = await _httpClient.PostAsync("tables", JsonHelper.GetJsonStringContent<CreateTableCommand>(createCommand));

            // Assert.
            Assert.True(response.StatusCode == expectedStatusCode);

        }

        [Fact]
        public async Task UpdateTable_WithModel_ThenReturnsOk()
        {
            //Arrange
            var expectedStatusCode = System.Net.HttpStatusCode.OK;

            var expectedContent = new TableDto
            {
                Capacity = 6,
                TableName = "D3",
                Id = 13
            };

            var updateCommand = new UpdateTableCommand()
            {
                Table = expectedContent
            };

            // Act.
            var response = await _httpClient.PutAsync("tables", JsonHelper.GetJsonStringContent<UpdateTableCommand>(updateCommand));

            // Assert.
            Assert.True(response.StatusCode == expectedStatusCode);

        }

        public void Dispose()
        {
           
        }
    }
}

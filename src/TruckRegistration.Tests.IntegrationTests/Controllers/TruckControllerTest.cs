using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Services.Api;
using TruckRegistration.Tests.ComponentTests.Config;
using TruckRegistration.Tests.UnitTest.Database.Entities;
using Xunit;

namespace TruckRegistration.Tests.ComponentTests.Controllers
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class TruckControllerTest
    {
        private readonly IntegrationTestsFixture<StartupTest> _testsFixture;
        private readonly string baseURI = "truck-registration/v1/trucks";
        public TruckControllerTest(IntegrationTestsFixture<StartupTest> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Add Truck with success")]
        public async Task Add_Truck_Test_With_Success()
        {
            // Arrange
            var json = JsonConvert.SerializeObject(TruckEntityMock.GetTruck());
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _testsFixture.Client.PostAsync(baseURI, data);

            // Assert
            response.Should().BeSuccessful();
        }

        [Fact(DisplayName = "Get All Trucks with success and contains items")]
        public async Task GetAll_Test_Contains_Items()
        {
            // Arrange
            IEnumerable<TruckResponse> trucks = null;

            // Act
            var response = await _testsFixture.Client.GetAsync(baseURI);

            if (response.IsSuccessStatusCode)
            {
                var contentResponse = await response.Content.ReadAsStringAsync();

                if (contentResponse != null)
                {
                    trucks = JsonConvert.DeserializeObject<IEnumerable<TruckResponse>>(contentResponse);
                }
            }

            // Assert
            response.Should().BeSuccessful();
            trucks.Should().NotBeNull();
            trucks.Should().NotBeEmpty();
        }
    }
}

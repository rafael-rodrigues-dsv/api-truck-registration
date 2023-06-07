using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Application.Services;
using TruckRegistration.Domain.Contracts.Commands;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Tests.UnitTest.Database.Entities;
using TruckRegistration.Tests.UnitTest.Database.Models.Response;
using Xunit;

namespace TruckRegistration.Tests.UnitTest.Application
{
    public class TruckServiceAppTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITruckCommandHandler> _truckCommandHandlerMock;
        private readonly Mock<ITruckRepository> _truckRepositoryMock;
        private readonly TruckAppService _truckAppService;

        public TruckServiceAppTests()
        {
            _mapperMock = new Mock<IMapper>();
            _truckCommandHandlerMock = new Mock<ITruckCommandHandler>();
            _truckRepositoryMock = new Mock<ITruckRepository>();

            _truckAppService = new TruckAppService(_mapperMock.Object,
                _truckCommandHandlerMock.Object,
                _truckRepositoryMock.Object);
        }

        [Fact(DisplayName = "Get All Trucks contains items")]
        public async Task GetAll_Test_Contains_Items()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(TruckEntityMock.GetTruckList());

            _mapperMock.Setup(m => m.Map<IEnumerable<TruckResponse>>(It.IsAny<List<Truck>>()))
                .Returns(TruckResponseMock.GetList());

            // Act
            var result = await _truckAppService.GetAll();

            // Assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "Get All Trucks not contains items")]
        public async Task GetAll_Test_NotContains_Items()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(It.IsAny<List<Truck>>());

            _mapperMock.Setup(m => m.Map<IEnumerable<TruckResponse>>(It.IsAny<List<Truck>>()))
                .Returns(It.IsAny<List<TruckResponse>>());

            // Act
            var result = await _truckAppService.GetAll();

            // Assert
            result.Should().BeNullOrEmpty();
        }

        [Fact(DisplayName = "Get By Id Trucks contains item")]
        public async Task GetById_Test_Contains_Item()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(TruckEntityMock.GetTruck());

            _mapperMock.Setup(m => m.Map<TruckResponse>(It.IsAny<Truck>()))
                .Returns(TruckResponseMock.GetTruck());

            // Act
            var result = await _truckAppService.GetById(It.IsAny<System.Guid>());

            // Assert
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "Get By Id Trucks not contains item")]
        public async Task GetById_Test_Not_Contains_Item()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(It.IsAny<Truck>);

            _mapperMock.Setup(m => m.Map<TruckResponse>(It.IsAny<Truck>()))
                .Returns(It.IsAny<TruckResponse>);

            // Act
            var result = await _truckAppService.GetById(It.IsAny<System.Guid>());

            // Assert
            result.Should().BeNull();
        }
    }
}
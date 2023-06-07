using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using TruckRegistration.Domain.Commands;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Tests.UnitTest.Database.Entities;
using Xunit;

namespace TruckRegistration.Tests.UnitTest.Domain.Commands
{
    public class TruckCommandHandlerTests
    {
        private readonly Mock<ITruckRepository> _truckRepositoryMock;
        private readonly TruckCommandHandler _truckCommandHandler;
        public TruckCommandHandlerTests()
        {
            _truckRepositoryMock = new Mock<ITruckRepository>();

            _truckCommandHandler = new TruckCommandHandler(_truckRepositoryMock.Object);
        }

        [Fact(DisplayName = "Add Truck with success")]
        public async Task Add_Truck_Test_With_Success()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.SaveOrUpdate(It.IsAny<Truck>()))
                .ReturnsAsync(TruckEntityMock.GetTruck());

            _truckRepositoryMock.Setup(m => m.Commit());

            // Act
            var result = await _truckCommandHandler.Add(TruckEntityMock.GetTruck(withGuidId: false));

            // Assert
            result.ValidationResult.IsValid.Should().BeTrue();
            result.Id.Should().NotBe(Guid.Empty);
            _truckRepositoryMock.Verify(m => m.SaveOrUpdate(It.IsAny<Truck>()), Times.Once);
            _truckRepositoryMock.Verify(m => m.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Add Truck with errors")]
        public async Task Add_Truck_Test_With_Errors()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.SaveOrUpdate(It.IsAny<Truck>()))
                .ReturnsAsync(It.IsAny<Truck>());

            // Act
            var result = await _truckCommandHandler.Add(new Truck());

            // Assert
            result.ValidationResult.IsValid.Should().BeFalse();
            result.ValidationResult.Errors.Count.Should().BeGreaterThan(0);
            _truckRepositoryMock.Verify(m => m.SaveOrUpdate(It.IsAny<Truck>()), Times.Never);
            _truckRepositoryMock.Verify(m => m.Commit(), Times.Never);
        }

        [Fact(DisplayName = "Update Truck with success")]
        public async Task Update_Truck_Test_With_Success()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(TruckEntityMock.GetTruck());

            _truckRepositoryMock.Setup(m => m.SaveOrUpdate(It.IsAny<Truck>()))
                .ReturnsAsync(TruckEntityMock.GetTruck());

            _truckRepositoryMock.Setup(m => m.Commit());

            // Act
            var result = await _truckCommandHandler.Update(TruckEntityMock.GetTruck());

            // Assert
            result.ValidationResult.IsValid.Should().BeTrue();
            _truckRepositoryMock.Verify(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()), Times.Exactly(2));
            _truckRepositoryMock.Verify(m => m.SaveOrUpdate(It.IsAny<Truck>()), Times.Once);
            _truckRepositoryMock.Verify(m => m.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Update Truck with errors")]
        public async Task Update_Truck_Test_With_Errors()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.SaveOrUpdate(It.IsAny<Truck>()))
                .ReturnsAsync(It.IsAny<Truck>());

            // Act
            var result = await _truckCommandHandler.Update(new Truck());

            // Assert
            result.ValidationResult.IsValid.Should().BeFalse();
            result.ValidationResult.Errors.Count.Should().BeGreaterThan(0);
            _truckRepositoryMock.Verify(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()), Times.Once);
            _truckRepositoryMock.Verify(m => m.SaveOrUpdate(It.IsAny<Truck>()), Times.Never);
            _truckRepositoryMock.Verify(m => m.Commit(), Times.Never);
        }

        [Fact(DisplayName = "Delete Truck with success")]
        public async Task Delete_Truck_Test_With_Success()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(TruckEntityMock.GetTruck());

            _truckRepositoryMock.Setup(m => m.Remove(It.IsAny<System.Guid>()))
                .ReturnsAsync(true);

            _truckRepositoryMock.Setup(m => m.Commit());

            // Act
            var result = await _truckCommandHandler.Delete(TruckEntityMock.GetTruck().Id);

            // Assert
            result.ValidationResult.IsValid.Should().BeTrue();
            _truckRepositoryMock.Verify(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()), Times.Once);
            _truckRepositoryMock.Verify(m => m.Remove(It.IsAny<System.Guid>()), Times.Once);
            _truckRepositoryMock.Verify(m => m.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Delete Truck with errors")]
        public async Task Delete_Truck_Test_With_Errors()
        {
            // Arrange
            _truckRepositoryMock.Setup(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(It.IsAny<Truck>());

            // Act
            var result = await _truckCommandHandler.Delete(It.IsAny<System.Guid>());

            // Assert
            result.ValidationResult.IsValid.Should().BeFalse();
            result.ValidationResult.Errors.Count.Should().BeGreaterThan(0);
            _truckRepositoryMock.Verify(m => m.GetById(It.IsAny<System.Guid>(), It.IsAny<bool>()), Times.Once);
            _truckRepositoryMock.Verify(m => m.Remove(It.IsAny<System.Guid>()), Times.Never);
            _truckRepositoryMock.Verify(m => m.Commit(), Times.Never);
        }
    }
}

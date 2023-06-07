using AutoMapper;
using FluentAssertions;
using TruckRegistration.Application.AutoMapper;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Tests.UnitTest.Database.Entities;
using TruckRegistration.Tests.UnitTest.Database.Models.Request;
using Xunit;

namespace TruckRegistration.Tests.UnitTest.Application.AutoMapper
{
    public class AutoMapperMappingTests
    {
        private readonly IMapper _mapper;

        public AutoMapperMappingTests()
        {
            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();
        }

        [Fact(DisplayName = "Validate Map AddTruckRequest To Truck Test is valid")]
        public void Validate_Map_AddTruckRequestToTruck_Test_Is_Valid()
        {
            // Arrange
            var request = TruckRequestMock.GetAddTruck();

            // Act
            var result = _mapper.Map<Truck>(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(new System.Guid());
            result.Description.Should().Be(request.Description);
            result.Model.Should().Be(request.Model);
            result.ManufactureYear.Should().Be(request.ManufactureYear);
            result.ModelYear.Should().Be(request.ModelYear);
            result.Renavam.Should().Be(request.Renavam);
            result.Color.Should().Be(request.Color);
        }

        [Fact(DisplayName = "Validate Map UpdateTruckRequest To Truck Test is valid")]
        public void Validate_Map_UpdateTruckRequestToTruck_Test_Is_Valid()
        {
            // Arrange
            var request = TruckRequestMock.GetUpdateTruck();

            // Act
            var result = _mapper.Map<Truck>(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(new System.Guid());
            result.Description.Should().Be(request.Description);
            result.Model.Should().Be(request.Model);
            result.ManufactureYear.Should().Be(request.ManufactureYear);
            result.ModelYear.Should().Be(request.ModelYear);
            result.Renavam.Should().Be(request.Renavam);
            result.Color.Should().Be(request.Color);
        }

        [Fact(DisplayName = "Validate Map Truck To TruckResponse Test is valid")]
        public void Validate_Map_TruckToTruckResponse_Test_Is_Valid()
        {
            // Arrange
            var model = TruckEntityMock.GetTruck();

            // Act
            var result = _mapper.Map<TruckResponse>(model);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(model.Id);
            result.Description.Should().Be(model.Description);
            result.Model.Should().Be(model.Model);
            result.ManufactureYear.Should().Be(model.ManufactureYear);
            result.ModelYear.Should().Be(model.ModelYear);
            result.Renavam.Should().Be(model.Renavam);
            result.Color.Should().Be(model.Color);
        }
    }
}

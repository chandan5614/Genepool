using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.CQRS.Commands;
using Genepool.Architectures.CleanArchitecture.CQRS.Commands.Handlers;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Core.Entities;

namespace Genepool.Architectures.CleanArchitecture.Testing.UnitTests.CommandHandlers
{
    public class CreateVehicleCommandHandlerTests
    {
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        private readonly CreateVehicleCommandHandler _handler;

        public CreateVehicleCommandHandlerTests()
        {
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _handler = new CreateVehicleCommandHandler(_mockVehicleRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddVehicleAndReturnDto()
        {
            // Arrange
            var vehicleDto = new VehicleDto
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2022,
                Color = "Blue",
                OwnerId = Guid.NewGuid()
            };

            var command = new CreateVehicleCommand(vehicleDto);
            var vehicle = new Vehicle
            {
                Id = Guid.NewGuid(),
                Make = vehicleDto.Make,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Color = vehicleDto.Color,
                OwnerId = vehicleDto.OwnerId
            };

            _mockVehicleRepository.Setup(repo => repo.AddVehicleAsync(It.IsAny<Vehicle>()))
                .ReturnsAsync(vehicle);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vehicleDto.Make, result.Make);
            _mockVehicleRepository.Verify(repo => repo.AddVehicleAsync(It.IsAny<Vehicle>()), Times.Once);
        }
    }
}

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
    public class UpdateVehicleCommandHandlerTests
    {
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        private readonly UpdateVehicleCommandHandler _handler;

        public UpdateVehicleCommandHandlerTests()
        {
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _handler = new UpdateVehicleCommandHandler(_mockVehicleRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateVehicleAndReturnDto()
        {
            // Arrange
            var vehicleDto = new VehicleDto
            {
                Id = Guid.NewGuid(),
                Make = "Honda",
                Model = "Civic",
                Year = 2023,
                Color = "Red",
                OwnerId = Guid.NewGuid()
            };

            var command = new UpdateVehicleCommand(vehicleDto);
            var vehicle = new Vehicle
            {
                Id = vehicleDto.Id,
                Make = vehicleDto.Make,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                Color = vehicleDto.Color,
                OwnerId = vehicleDto.OwnerId
            };

            _mockVehicleRepository.Setup(repo => repo.UpdateVehicleAsync(It.IsAny<Vehicle>()))
                .ReturnsAsync(vehicle);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vehicleDto.Id, result.Id);
            _mockVehicleRepository.Verify(repo => repo.UpdateVehicleAsync(It.IsAny<Vehicle>()), Times.Once);
        }
    }
}

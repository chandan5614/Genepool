using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Genepool.Architectures.CleanArchitecture.CQRS.Commands;
using Genepool.Architectures.CleanArchitecture.CQRS.Commands.Handlers;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;

namespace Genepool.Architectures.CleanArchitecture.Testing.UnitTests.CommandHandlers
{
    public class DeleteVehicleCommandHandlerTests
    {
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        private readonly DeleteVehicleCommandHandler _handler;

        public DeleteVehicleCommandHandlerTests()
        {
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _handler = new DeleteVehicleCommandHandler(_mockVehicleRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteVehicleAndReturnTrue()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            _mockVehicleRepository.Setup(repo => repo.DeleteVehicleAsync(vehicleId))
                .ReturnsAsync(true);

            var command = new DeleteVehicleCommand(vehicleId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            _mockVehicleRepository.Verify(repo => repo.DeleteVehicleAsync(vehicleId), Times.Once);
        }
    }
}

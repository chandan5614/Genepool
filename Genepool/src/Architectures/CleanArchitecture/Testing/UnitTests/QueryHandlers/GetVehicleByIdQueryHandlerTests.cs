using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.CQRS.Queries;
using Genepool.Architectures.CleanArchitecture.CQRS.Queries.Handlers;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Core.Entities;

namespace Genepool.Architectures.CleanArchitecture.Testing.UnitTests.QueryHandlers
{
    public class GetVehicleByIdQueryHandlerTests
    {
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        private readonly GetVehicleByIdQueryHandler _handler;

        public GetVehicleByIdQueryHandlerTests()
        {
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _handler = new GetVehicleByIdQueryHandler(_mockVehicleRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnVehicleDto()
        {
            // Arrange
            var vehicleId = Guid.NewGuid();
            var vehicle = new Vehicle
            {
                Id = vehicleId,
                Make = "Tesla",
                Model = "Model S",
                Year = 2023,
                Color = "White",
                OwnerId = Guid.NewGuid()
            };

            _mockVehicleRepository.Setup(repo => repo.GetVehicleByIdAsync(vehicleId))
                .ReturnsAsync(vehicle);

            var query = new GetVehicleByIdQuery(vehicleId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(vehicleId, result.Id);
            _mockVehicleRepository.Verify(repo => repo.GetVehicleByIdAsync(vehicleId), Times.Once);
        }
    }
}

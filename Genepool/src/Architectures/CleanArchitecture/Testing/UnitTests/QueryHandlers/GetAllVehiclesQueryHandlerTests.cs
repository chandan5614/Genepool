using System;
using System.Collections.Generic;
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
    public class GetAllVehiclesQueryHandlerTests
    {
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        private readonly GetAllVehiclesQueryHandler _handler;

        public GetAllVehiclesQueryHandlerTests()
        {
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _handler = new GetAllVehiclesQueryHandler(_mockVehicleRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfVehicleDtos()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { Id = Guid.NewGuid(), Make = "Ford", Model = "Mustang", Year = 2022, Color = "Black", OwnerId = Guid.NewGuid() },
                new Vehicle { Id = Guid.NewGuid(), Make = "Chevrolet", Model = "Camaro", Year = 2023, Color = "Yellow", OwnerId = Guid.NewGuid() }
            };

            _mockVehicleRepository.Setup(repo => repo.GetAllVehiclesAsync())
                .ReturnsAsync(vehicles);

            var query = new GetAllVehiclesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _mockVehicleRepository.Verify(repo => repo.GetAllVehiclesAsync(), Times.Once);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.CQRS.Commands;
using Genepool.Architectures.CleanArchitecture.CQRS.Commands.Handlers;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Core.Entities;

public class CreateOwnerCommandHandlerTests
{
    private readonly Mock<IOwnerRepository> _mockRepository;
    private readonly CreateOwnerCommandHandler _handler;

    public CreateOwnerCommandHandlerTests()
    {
        _mockRepository = new Mock<IOwnerRepository>();
        _handler = new CreateOwnerCommandHandler(_mockRepository.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddOwnerAndReturnOwnerDto()
    {
        // Arrange
        var ownerDto = new OwnerDto { Name = "John Doe" };
        var ownerEntity = new Owner { Id = new Guid("ff776aa9-d196-4c06-9661-b8e4c2907f9b"), Name = "John Doe" };

        _mockRepository.Setup(repo => repo.AddOwnerAsync(It.IsAny<Owner>()))
            .ReturnsAsync(ownerEntity);

        var command = new CreateOwnerCommand(ownerDto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(ownerEntity.Id, result.Id);
        Assert.Equal(ownerEntity.Name, result.Name);
    }
}

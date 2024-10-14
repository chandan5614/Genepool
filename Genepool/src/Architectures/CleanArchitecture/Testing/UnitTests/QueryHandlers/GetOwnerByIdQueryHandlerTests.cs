using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Genepool.Architectures.CleanArchitecture.Application.Dtos;
using Genepool.Architectures.CleanArchitecture.CQRS.Queries;
using Genepool.Architectures.CleanArchitecture.CQRS.Queries.Handlers;
using Genepool.Architectures.CleanArchitecture.Core.Interfaces;
using Genepool.Architectures.CleanArchitecture.Core.Entities;
using System.Data.Common;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class GetOwnerByIdQueryHandlerTests
{
    private readonly Mock<IOwnerRepository> _mockRepository;
    private readonly GetOwnerByIdQueryHandler _handler;

    public GetOwnerByIdQueryHandlerTests()
    {
        _mockRepository = new Mock<IOwnerRepository>();
        _handler = new GetOwnerByIdQueryHandler(_mockRepository.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnOwnerDto_WhenOwnerExists()
    {
        // Arrange
        var ownerEntity = new Owner { Id = new Guid("ff776aa9-d196-4c06-9661-b8e4c2907f9b"), Name = "John Doe" };
        _mockRepository.Setup(repo => repo.GetOwnerByIdAsync(new Guid("ff776aa9-d196-4c06-9661-b8e4c2907f9b")))
            .ReturnsAsync(ownerEntity);

        var query = new GetOwnerByIdQuery(new Guid("ff776aa9-d196-4c06-9661-b8e4c2907f9b"));

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(ownerEntity.Id, result.Id);
        Assert.Equal(ownerEntity.Name, result.Name);
    }
}

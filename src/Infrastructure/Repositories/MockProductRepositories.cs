using DistributedJoins.Domain.Ports.Repositories.Interfaces;
using DistributedJoins.Domain.ProductAggregate;
using DistributedJoins.Domain.Ports.TestData;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


/// <summary>
/// Mock implementation returning a static product list for simplicity
/// </summary>
public class MockProductRepository : IProductRepository
{
    private static readonly List<Product> _products = new()
    {
        new Product(
            IdConsts.Product1Id,
            "Product 1",
            DateTime.UtcNow,
            IdConsts.User1Id,
            IdConsts.Rating1Id
        ),
        new Product(
            IdConsts.Product2Id,
            "Product 2",
            DateTime.UtcNow,
            IdConsts.User2Id,
            IdConsts.Rating2Id
        ),
        new Product(
            IdConsts.Product3Id,
            "Product 3",
            DateTime.UtcNow,
            IdConsts.User3Id,
            IdConsts.Rating3Id
        )
    };

    public Task<IEnumerable<Product>> GetPaginated(int index, int offset, CancellationToken cancellationToken)
    {
        var paginatedResult = _products
            .Skip(index)
            .Take(offset);

        return Task.FromResult(paginatedResult);
    }
}
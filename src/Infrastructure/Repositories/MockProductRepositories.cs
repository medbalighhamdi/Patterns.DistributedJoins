using DistributedJoins.Domain.Ports.Repositories.Interfaces;
using DistributedJoins.Domain.ProductAggregate;


/// <summary>
/// Mock implementation returning a mock product list for simplicity
/// </summary>
public class MockProductRepository : IProductRepository
{
    public Task<IEnumerable<Product>> GetPaginated(int index, int offset, CancellationToken cancellationToken)
    {
        return Task.FromResult<IEnumerable<Product>>(new List<Product>());
    }
}

using Patterns.DistributedJoins.Domain.ProductAggregate;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetPaginated(int index, int offset, CancellationToken cancellationToken);
}
using DistributedJoins.Domain.ProductAggregate;

namespace DistributedJoins.Domain.Ports.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetPaginated(int index, int offset, CancellationToken cancellationToken);
}

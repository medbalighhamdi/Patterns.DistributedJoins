using DistributedJoins.Domain.Ports.Adapters.Models;
using DomainProduct = DistributedJoins.Domain.ProductAggregate.Product;

namespace DistributedJoins.Domain.Ports.DistributedJoins.Product.Interfaces;

public interface IProductUserJoiner
{
    Task<IDictionary<Guid, User>> JoinWithUser(IEnumerable<DomainProduct> products, CancellationToken cancellationToken);
}

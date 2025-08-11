using DistributedJoins.Domain.Ports.Adapters.Models;
using DomainProduct = DistributedJoins.Domain.ProductAggregate.Product;

namespace DistributedJoins.Domain.Ports.DistributedJoins.Product.Interfaces;

public interface IProductRatingJoiner
{
    Task<IDictionary<Guid, Rating>> JoinWithRating(IEnumerable<DomainProduct> products, CancellationToken cancellationToken);
}

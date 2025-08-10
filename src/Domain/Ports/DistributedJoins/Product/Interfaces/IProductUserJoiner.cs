using Patterns.DistributedJoins.Domain.ProductAggregate;

public interface IProductUserJoiner
{
    Task<IDictionary<Guid, User>> JoinWithUser(IEnumerable<Product> products, CancellationToken cancellationToken);
}
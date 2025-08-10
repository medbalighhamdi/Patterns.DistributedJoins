using Patterns.DistributedJoins.Domain.ProductAggregate;

public interface IProductRatingJoiner
{
    Task<IDictionary<Guid, Rating>> JoinWithRating(IEnumerable<Product> products, CancellationToken cancellationToken);
}
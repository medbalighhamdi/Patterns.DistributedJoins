
using DistributedJoins.Domain.Ports.Adapters.Interfaces;
using DistributedJoins.Domain.Ports.Adapters.Models;
using DistributedJoins.Domain.Ports.DistributedJoins.Product.Interfaces;
using DistributedJoins.Domain.ProductAggregate;

public class ProductRatingJoiner(IRatingAdapter RatingAdapter) : IProductRatingJoiner
{
    public async Task<IDictionary<Guid, Rating>> JoinWithRating(IEnumerable<Product> products, CancellationToken cancellationToken)
    {
        // 1 - index concerned ratings from rating service
      var ratingIds = products.Select(p => p.RatingId).Distinct();
      var distributedRatings = await RatingAdapter.GetRatingsByIds(
        ratingIds.ToHashSet(), cancellationToken);
      var joinedRatingsByIdMap = distributedRatings.ToDictionary(r => r.Id,
                                                                 r => r);

        // 2 - dispatch users by product
        return products.ToDictionary
          (p => p.Id,
            p => joinedRatingsByIdMap[p.RatingId]);
    }
}

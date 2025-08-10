namespace DistributedJoins.Domain.Ports.Adapters.Interfaces;

public interface IRatingAdapter
{
    Task<IEnumerable<Rating>> GetRatingsByIds(IEnumerable<Guid> ratingIds, CancellationToken cancellationToken);
}
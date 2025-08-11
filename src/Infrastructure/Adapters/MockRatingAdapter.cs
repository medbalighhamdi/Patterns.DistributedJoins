using DistributedJoins.Domain.Ports.Adapters.Interfaces;
using DistributedJoins.Domain.Ports.Adapters.Models;

namespace DistributedJoins.Infrastructure.Adapters;

public class MockRatingAdapter : IRatingAdapter
{
    private readonly IDictionary<Guid, Rating> _ratings;

    public MockRatingAdapter()
    {
        _ratings = new Dictionary<Guid, Rating>
        {
            { Guid.NewGuid(), new Rating(Guid.NewGuid(), 5, "Excellent movie") },
            { Guid.NewGuid(), new Rating(Guid.NewGuid(), 4, "Good film") },
            { Guid.NewGuid(), new Rating(Guid.NewGuid(), 3, "Average film") }
    }   ;
    }

    public Task<IEnumerable<Rating>> GetRatingsByIds(IEnumerable<Guid> ratingIds, CancellationToken cancellationToken)
    {
        var ratings = _ratings.Where(r => ratingIds.Contains(r.Key)).Select(r => r.Value);
        return Task.FromResult(ratings);
    }
}
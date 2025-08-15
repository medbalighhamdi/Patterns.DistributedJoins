using DistributedJoins.Domain.Ports.Adapters.Interfaces;
using DistributedJoins.Domain.Ports.Adapters.Models;
using DistributedJoins.Domain.Ports.TestData;

namespace DistributedJoins.Infrastructure.Adapters;

public class MockRatingAdapter : IRatingAdapter
{
    private readonly List<Rating> _ratings;

    public MockRatingAdapter()
    {
        _ratings = new List<Rating>
        {
            new Rating(IdConsts.Rating1Id, 5, "Excellent movie"),
            new Rating(IdConsts.Rating2Id, 4, "Good film"),
            new Rating(IdConsts.Rating3Id, 3, "Average film")
    }   ;
    }

    public Task<IEnumerable<Rating>> GetRatingsByIds(HashSet<Guid> ratingIds, CancellationToken cancellationToken)
    {
        var filteredRatings = _ratings.Where(remoteUser => ratingIds.Contains(remoteUser.Id));
        return Task.FromResult(filteredRatings.AsEnumerable());
    }
}
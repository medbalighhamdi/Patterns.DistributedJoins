using DistributedJoins.Domain.Ports.Adapters.Interfaces;
using DistributedJoins.Domain.Ports.Adapters.Models;
using DistributedJoins.Domain.Ports.TestData;

namespace DistributedJoins.Infrastructure.Adapters;

public class MockUserAdapter : IUserAdapter
{
    private readonly List<User> _users;

    public MockUserAdapter()
    {
        _users = new List<User>
        {
            new User(IdConsts.User1Id, "Alice", "alice@domain.com"),
            new User(IdConsts.User2Id, "Bob", "bob@domain.com"),
            new User(IdConsts.User3Id, "Charlie", "charlie@domain.com")
        };
    }

    public Task<IEnumerable<User>> GetUsersByIds(HashSet<Guid> userIds, CancellationToken cancellationToken)
    {
        var filteredUsers = _users.Where(remoteUser => userIds.Contains(remoteUser.Id));
        return Task.FromResult(filteredUsers.AsEnumerable());
    }
}

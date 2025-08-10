using Patterns.DistributedJoins.Domain.ProductAggregate;

public class MockUserAdapter : IUserAdapter
{
    private readonly Dictionary<Guid, User> _users;

    public MockUserAdapter()
    {
        _users = new Dictionary<Guid, User>
        {
            { Guid.NewGuid(), new User(Guid.NewGuid(), "Alice", "alice@domain.com") },
            { Guid.NewGuid(), new User(Guid.NewGuid(), "Bob", "bob@domain.com")},
            { Guid.NewGuid(), new User(Guid.NewGuid(), "Charlie", "charlie@domain.com") }
        };
    }

    public Task<IEnumerable<User>> GetUsersByIds(IEnumerable<Guid> userIds, CancellationToken cancellationToken)
    {
        var result = _users.Where(u => userIds.Contains(u.Key)).Select(u => u.Value);
        return Task.FromResult(result.AsEnumerable());
    }
}
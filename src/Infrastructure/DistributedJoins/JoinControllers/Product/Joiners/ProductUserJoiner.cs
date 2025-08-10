using Patterns.DistributedJoins.Domain.ProductAggregate;
using System.Linq;

public class ProductUserJoiner(IUserAdapter UserAdapter) : IProductUserJoiner
{
    public async Task<IDictionary<Guid, User>> JoinWithUser(IEnumerable<Product> products, CancellationToken cancellationToken)
    {
        // 1 - index concerned users
        var usersIds = products.Select(p => p.PostedByUserId).Distinct();
        var joinedUsers =await  UserAdapter.GetUsersByIds(
          usersIds, cancellationToken);
        var joinedUsersByIdMap = joinedUsers.ToDictionary(u => u.Id);

        // 2 - dispatch users by product
        return products.ToDictionary
          (p => p.Id,
           p => joinedUsersByIdMap[p.PostedByUserId]
          );
    }
}

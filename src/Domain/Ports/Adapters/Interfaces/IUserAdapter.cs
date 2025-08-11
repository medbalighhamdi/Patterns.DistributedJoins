using DistributedJoins.Domain.Ports.Adapters.Models;

namespace DistributedJoins.Domain.Ports.Adapters.Interfaces;

/// <summary>
/// Adapter interface for user-related operations queried from a user service.
/// </summary>
public interface IUserAdapter
{
    /// <summary>
    /// Connects to the user service and retrieves users by their IDs.
    /// This method is used to fetch user details for products posted by users.
    /// It allows for distributed joins by fetching user data based on product information.
    /// </summary>
    /// <param name="userIds"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<User>> GetUsersByIds(IEnumerable<Guid> userIds, CancellationToken cancellationToken);
}

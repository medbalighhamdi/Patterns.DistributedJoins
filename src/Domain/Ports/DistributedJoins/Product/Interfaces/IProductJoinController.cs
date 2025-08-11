using DistributedJoins.Domain.Ports.DistributedJoins.Product.Models;

namespace DistributedJoins.Domain.Ports.DistributedJoins.Product.Interfaces;

public interface IProductJoinController
{
    Task<IEnumerable<ProductWithDistributedData>> JoinProductWithDistributedData(
        int index,
        int offset,
        ProductJoinControls productJoinControls,
        CancellationToken cancellationToken);
}

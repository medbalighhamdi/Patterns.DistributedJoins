public interface IProductJoinController
{
    Task<IEnumerable<ProductWithDistributedData>> JoinProductWithDistributedData(
        int index,
        int offset,
        ProductJoinControls productJoinControls,
        CancellationToken cancellationToken);
}
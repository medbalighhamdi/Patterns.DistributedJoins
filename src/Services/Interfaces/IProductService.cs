namespace DistributedJoins.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductCard>> GetCards(CancellationToken cancellationToken);
}

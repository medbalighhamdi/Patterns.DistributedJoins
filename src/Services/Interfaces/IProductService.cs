public interface IProductService
{
    Task<IEnumerable<ProductCard>> GetCards(IEnumerable<Guid> productIds, CancellationToken cancellationToken);
}   
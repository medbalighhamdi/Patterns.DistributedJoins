using DistributedJoins.Domain.Ports.Adapters.Models;
using DistributedJoins.Domain.Ports.DistributedJoins.Product.Interfaces;
using DistributedJoins.Domain.Ports.DistributedJoins.Product.Models;
using DistributedJoins.Domain.Ports.Repositories.Interfaces;
using DomainProduct = DistributedJoins.Domain.ProductAggregate.Product;

namespace DistributedJoins.Infrastructure.DistributedJoins.JoinControllers.Product;

public class ProductJoinController(IProductUserJoiner ProductUserJoiner, IProductRatingJoiner ProductRatingJoiner, IProductRepository ProductRepository) : IProductJoinController
{
  /// </inheritdoc>
  public async Task<IEnumerable<ProductWithDistributedData>> JoinProductWithDistributedData(
      int index,
      int offset,
      ProductJoinControls productJoinControls,
      CancellationToken cancellationToken)
  {
    // get and paginate product results
    var products = await ProductRepository.GetPaginated(index, offset, cancellationToken);

    // get joins based on provided controls
    var userByProductIdMap = await JoinWithUser(products, productJoinControls, cancellationToken);
    var ratingByProductIdMap = await JoinWithRating(products, productJoinControls, cancellationToken);

    // dispatch final result
    return products.Select(p =>
        new ProductWithDistributedData(
            p,
            userByProductIdMap[p.Id],
            ratingByProductIdMap[p.Id]));
  }

  ///<summary>
  /// Join product with users based on the given join control
  ///</summary>
  private async Task<IDictionary<Guid, User>> JoinWithUser(
    IEnumerable<DomainProduct> products,
    ProductJoinControls joinControls,
    CancellationToken cancellationToken)
  {
    if (!joinControls.JoinWithUser)
      return new Dictionary<Guid, User>();
    // join got products with distributed users data
    return await ProductUserJoiner.JoinWithUser(products, cancellationToken);
  }

  ///<summary>
  /// Join product with rating based on the given join control
  ///</summary>
  private async Task<IDictionary<Guid, Rating>> JoinWithRating(
    IEnumerable<DomainProduct> products,
    ProductJoinControls joinControls,
    CancellationToken cancellationToken)
  {
    if (!joinControls.JoinWithRating)
      return new Dictionary<Guid, Rating>();
    // join got products with distributed ratings data
    return await ProductRatingJoiner.JoinWithRating(products, cancellationToken);
  }
}

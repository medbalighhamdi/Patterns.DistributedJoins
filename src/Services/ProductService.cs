
using DistributedJoins.Domain.Ports.DistributedJoins.Product.Interfaces;
using DistributedJoins.Domain.Ports.DistributedJoins.Product.Models;
using DistributedJoins.Services.Interfaces;

namespace DistributedJoins.Services;

public class ProductService(IProductJoinController ProductJoinController) : IProductService
{
    public async Task<IEnumerable<ProductCard>> GetCards(IEnumerable<Guid> productIds, CancellationToken cancellationToken)
    {
        var productsWithDistributedData = await ProductJoinController.JoinProductWithDistributedData(
            0,
            100,
            ProductJoinControls.Initiate().InnerJoinUsers().InnerJoinRatings(),
            cancellationToken);

        return productsWithDistributedData.Select(p =>
            new ProductCard(
                p.Product,
                new ProductCardUserInfo(p.PostedByUser),
                new ProductCardRatinginfo(p.Rating))
        );
    }
}

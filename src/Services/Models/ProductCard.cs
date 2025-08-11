using DistributedJoins.Domain.Ports.Adapters.Models;
using DistributedJoins.Domain.ProductAggregate;

public record ProductCard(Product Product, ProductCardUserInfo UserInfo, ProductCardRatinginfo RatingInfo);

public record ProductCardUserInfo(Guid UserId, string UserName, string UserEmail)
{
    public ProductCardUserInfo(User user) : this(user.Id, user.Name, user.Email) { }
};

public record ProductCardRatinginfo(Guid RatingId, string Comment, decimal Score)
{
    public ProductCardRatinginfo(Rating rating) : this(rating.Id, rating.Comment, rating.Score) { }
};
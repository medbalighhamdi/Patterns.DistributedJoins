namespace DistributedJoins.Api.Dtos;

public record CardDto
{
    public string Id { get; init; }
    public string Name { get; init; }
    public DateTime CreatedAt { get; init; }
    public string UserName { get; init; }
    public decimal ProductScore { get; init; }

    public CardDto(ProductCard productCard)
    {
        Id = productCard.Product.Id.ToString();
        Name = productCard.Product.Name;
        CreatedAt = productCard.Product.InventoryCreatedAt;
        UserName = productCard.UserInfo.UserName;
        ProductScore = productCard.RatingInfo.Score;
    }
}

namespace DistributedJoins.Domain.Ports.DistributedJoins.Product.Models;
public record ProductJoinControls
{
    public bool JoinWithUser { get; init; } = false;
    public bool JoinWithRating { get; init; } = false;

    private ProductJoinControls()
    {
        JoinWithUser = false;
        JoinWithRating = false;
    }
    public static ProductJoinControls Initiate()
    {
        return new ProductJoinControls();
    }

    public ProductJoinControls InnerJoinUsers()
    {
        return this with { JoinWithUser = true };
    }

    public ProductJoinControls InnerJoinRatings()
    {
        return this with { JoinWithRating = true };
    }
}